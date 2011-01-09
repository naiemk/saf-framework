using System;
using System.Runtime.Serialization;
using saf.Base;

namespace saf.Authorization
{
    [DataContract]
    public class TypeAuthorizationToken : Tuple<bool, bool>
    {
        public TypeAuthorizationToken(bool visible, bool editable) : base(visible, editable)
        {
        }

        public bool Visible { get { return Item1; } }
        public bool Editable { get { return Item2; } }

        public static TypeAuthorizationToken Make( IAccess<Permission> perm)
        {
            return new TypeAuthorizationToken(
                    perm.Key.HasFlag(Permission.View) || perm.Key.HasFlag(Permission.Own),
                    perm.Key.HasFlag(Permission.Edit) || perm.Key.HasFlag(Permission.Own)
                );
        }
    }
}
