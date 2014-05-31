using System;

namespace NHibernate.Bitwise.Tests.Domain
{
    [Flags]
    public enum Permissions
    {
        Read = 1 << 0,
        Write = 1 << 1
    }
}