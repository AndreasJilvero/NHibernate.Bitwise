using System.Reflection;
using NHibernate.Bitwise.Tests.Mappings;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;

namespace NHibernate.Bitwise.Tests
{
    public class NHibernateFactory
    {
        private readonly Configuration _configuration;

        public NHibernateFactory()
        {
            _configuration = new Configuration().DataBaseIntegration(db =>
            {
                db.Driver<SQLite20Driver>();
                db.Dialect<SQLiteDialect>();
                db.ConnectionString = "data source=:memory:";
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.ConnectionReleaseMode = ConnectionReleaseMode.OnClose;
            });

            var modelMapper = new ModelMapper();
            var types = Assembly.GetAssembly(typeof(UserMap)).GetExportedTypes();
            modelMapper.AddMappings(types);
            _configuration.AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities());
        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }

        public ISessionFactory GetSessionFactory()
        {
            return _configuration.BuildSessionFactory();
        }
    }
}