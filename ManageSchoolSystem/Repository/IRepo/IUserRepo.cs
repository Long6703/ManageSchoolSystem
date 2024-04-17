using Share.EditModel;
using Share.Model;
using Share.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepo
{
    public interface IUserRepo
    {
        public List<User> GetAllStudent();
        public (List<User>, int total) GetAllStudentForPagging(int offset, int count, string searchString, List<int> classId);
        public bool CreateStudent(UserEditModel useredit);
        public bool EditStudent(int id, UserEditModel u);
        public User GetStudentById(int id);
        public bool DeleteStudent(int id);
        public List<Classs> GetClassses();
    }
}
