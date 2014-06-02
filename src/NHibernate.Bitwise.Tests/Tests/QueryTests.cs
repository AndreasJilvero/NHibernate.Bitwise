using NHibernate.Bitwise.Tests.Domain;
using NUnit.Framework;

namespace NHibernate.Bitwise.Tests.Tests
{
    [TestFixture]
    public class QueryTests : TestBase
    {
        [Test]
        public void CanStoreUser()
        {
            CreateUser(Permissions.Read);
            var users = Query(x => x.QueryOver<User>().List());
            Assert.IsNotEmpty(users);
        }

        [Test]
        public void ExactMatch_ReturnsMatchingUser()
        {
            CreateUser(Permissions.Read | Permissions.Write);
            var users = Query(session => session.QueryOver<User>().Where(x => x.Permissions == (Permissions.Read | Permissions.Write)).List());
            Assert.That(users.Count == 1);
        }

        [Test]
        public void HasAny_WithMatch_ReturnsMatchedUsers()
        {
            CreateUser(Permissions.Read | Permissions.Write | Permissions.Full);
            CreateUser(Permissions.Write);
            CreateUser(Permissions.Read);

            var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasAny(Permissions.Read, Permissions.Write);
            var users = Query(session => session.QueryOver<User>().Where(criteria).List());
            Assert.That(users.Count == 3);
        }

        [Test]
        public void HasAny_WithMatch_ReturnsNoUser()
        {
            CreateUser(Permissions.Full);
            var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasAny(Permissions.Read, Permissions.Write);
            var users = Query(session => session.QueryOver<User>().Where(criteria).List());
            Assert.IsEmpty(users);
        }

        [Test]
        public void HasBit_WithMatch_ReturnsMatchedUser()
        {
            CreateUser(Permissions.Read | Permissions.Full);
            var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasBit(Permissions.Read);
            var users = Query(session => session.QueryOver<User>().Where(criteria).List());
            Assert.That(users.Count == 1);
        }

        [Test]
        public void HasBit_WithoutMatch_ReturnsNoUser()
        {
            CreateUser(Permissions.Read | Permissions.Full);
            var criteria = BitwiseExpression.On<User>(x => x.Permissions).HasBit(Permissions.Write);
            var users = Query(session => session.QueryOver<User>().Where(criteria).List());
            Assert.IsEmpty(users);
        }
    }
}