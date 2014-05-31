namespace NHibernate.Bitwise.Tests.Domain
{
    public class User
    {
        public User() { }
        public User(string name, Permissions permissions)
        {
            Name = name;
            Permissions = permissions;
        }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Permissions Permissions { get; set; }
    }
}