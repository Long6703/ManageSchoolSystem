using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using FluentNHibernate;
using Share.Model;
using Repository.Mappings;

namespace Repository
{
    public class NHibernateConfig
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString("server=(local);database=ManageSchoolSystem2;uid=sa;pwd=123;TrustServerCertificate=true;"))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
