using System;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace NHibernate.Bitwise.Tests.Tests
{
    public class TestBase
    {
        public ISession Session { get; private set; }

        [SetUp]
        public void Init()
        {
            var factory = new NHibernateFactory();
            var configuration = factory.GetConfiguration();
            var sessionFactory = factory.GetSessionFactory();

            Session = sessionFactory.OpenSession();
            new SchemaExport(configuration).Execute(true, true, false, Session.Connection, Console.Out);
        }

        [TearDown]
        public void Dispose()
        {
            Session.Dispose();
        }
    }
}