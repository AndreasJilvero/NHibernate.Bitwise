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
            var user = new User { Name = "John Doe", Permissions = Permissions.Read };
            Session.Save(user);
            Session.Flush();
            Session.Clear();
            var users = Session.QueryOver<User>().List();
            Assert.IsNotEmpty(users);
        }
    }
}