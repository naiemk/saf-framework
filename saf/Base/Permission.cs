using System;

namespace saf.Base
{
    [Flags]
    public enum Permission
    {
        None = 0, View = 1, Edit = 2, Create = 4, Delete = 8, Own = 16, All = 32-1
    }
}
