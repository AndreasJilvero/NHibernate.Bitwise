using NHibernate.Bitwise.Tests.Domain;
using NUnit.Framework;

namespace NHibernate.Bitwise.Tests.Tests
{
    [TestFixture]
    public class Can_Store_User : TestBase
    {
        [Test]
        public void CanStoreUser()
        {
            var user = new User("John Doe", Permissions.Read);
            Persist(user);
            Forget(user);
            var users = Query(x => x.QueryOver<User>().List());
            Assert.IsNotEmpty(users);
        }
    }
}