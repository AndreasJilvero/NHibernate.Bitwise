using System;
using NHibernate.Bitwise.Tests.Domain;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NHibernate.Bitwise.Tests.Tests
{
    public class TestBase
    {
        private ISession _session;

        [SetUp]
        public void Init()
        {
            var factory = new NHibernateFactory();
            var configuration = factory.GetConfiguration();
            var sessionFactory = factory.GetSessionFactory();

            _session = sessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(true, true, false, _session.Connection, Console.Out);
        }

        [TearDown]
        public void Dispose()
        {
            _session.Dispose();
        }

        public void CreateUser(Permissions permissions)
        {
            var user = new User("My Johnson", permissions);
            _session.Save(user);
            _session.Evict(user);
        }

        public T Query<T>(Func<ISession, T> query)
        {
            return query(_session);
        }
    }
}