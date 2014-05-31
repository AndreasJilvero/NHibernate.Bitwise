using System;
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

        public void Persist<T>(T obj)
        {
            _session.Save(obj);
            _session.Flush();
        }

        public void Forget<T>(T obj)
        {
            _session.Evict(obj);
        }

        public T Get<T>(object id)
        {
            return _session.Get<T>(id);
        }

        public T Query<T>(Func<ISession, T> query)
        {
            return query(_session);
        }
    }
}