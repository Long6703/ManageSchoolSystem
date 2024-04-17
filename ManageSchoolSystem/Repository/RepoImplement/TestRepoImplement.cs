using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.IRepo;
using Share.Model;

namespace Repository.RepoImplement
{
    public class TestRepoImplement : ITestRepo
    {
        public Classs GetClassById(int id)
        {
            using (var session = NHibernateConfig.OpenSession())
            {
                return session.Get<Classs>(id);
            }
        }
    }
}
