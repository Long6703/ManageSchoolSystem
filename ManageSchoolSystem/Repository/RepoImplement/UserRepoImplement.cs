using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using Repository.IRepo;
using Share.EditModel;
using Share.Model;
using Share.Validation;
using Share.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Repository.RepoImplement
{
    public class UserRepoImplement : IUserRepo
    {
        public bool CreateStudent(UserEditModel useredit)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var classs = session.QueryOver<Classs>().Where(x => x.ClassName == useredit.ClassName).SingleOrDefault();
                        if (classs == null)
                        {
                            transaction.Rollback();
                            return false;
                        }
                        User user = new User()
                        {
                            DisplayName = useredit.DisplayName,
                            Email = useredit.Email,
                            Role = "student",
                            Class = classs,
                            PhoneNumber = useredit.PhoneNumber
                        };
                        session.Save(user);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        User user = session.QueryOver<User>().Where(x => x.UserID == id).SingleOrDefault();
                        if (user == null)
                        {
                            transaction.Rollback();
                            return false;
                        }
                        user.IsActive = false;
                        session.Update(user);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public bool EditStudent(int id, UserEditModel userupdate)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        User user = session.QueryOver<User>().Where(x => x.UserID == id).SingleOrDefault();
                        if (user == null)
                        {
                            transaction.Rollback();
                            return false;
                        }
                        user.DisplayName = userupdate.DisplayName;
                        user.Email = userupdate.Email;
                        user.PhoneNumber = userupdate.PhoneNumber;
                        var classs = session.QueryOver<Classs>().Where(x => x.ClassName == userupdate.ClassName).SingleOrDefault();
                        if (classs == null)
                        {
                            transaction.Rollback();
                            return false;
                        }
                        user.Class = classs;
                        session.Update(user);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                        Console.WriteLine(e.Message);
                        return false;
                    }
                }
            }
        }

        public List<User> GetAllStudent()
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var query = session.QueryOver<User>()
                            .Where(x => x.Role == "student" && x.IsActive == true)
                            .JoinQueryOver(x => x.Class)
                            .List().ToList();
                return query;
            }
        }

        public (List<User>, int total) GetAllStudentForPagging(int offset, int count, string searchString, List<int> classId)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var query = session.QueryOver<User>()
                .Where(x => x.Role == "student" && x.IsActive == true)
                .Where(x => x.DisplayName.IsInsensitiveLike($"%{searchString}%"));

                if (classId != null && classId.Any())
                {
                    query = query.WhereRestrictionOn(x => x.Class.ClassId).IsIn(classId);
                }

                int total = query.RowCount();

                var users = query
                    .JoinQueryOver(x => x.Class)
                    .Skip(offset)
                    .Take(count)
                    .List<User>();

                return (users.ToList(), total);
            }
        }

        public List<Classs> GetClassses()
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                return session.QueryOver<Classs>().List().ToList();
            }
        }

        public User GetStudentById(int id)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                var student = session.Get<User>(id);
                if (student == null || student.Role != "student" || student.IsActive == false)
                {
                    return null;
                }
                NHibernateUtil.Initialize(student.Class);
                return student;
            }
        }
    }
}
