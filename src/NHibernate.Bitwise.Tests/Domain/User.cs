namespace NHibernate.Bitwise.Tests.Domain
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Permissions Permissions { get; set; }
    }
}