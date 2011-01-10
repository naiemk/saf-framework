using System;
using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public abstract class AccessBase: IAccess<Permission>
    {
        [DataMember]
        protected readonly Permission Permission;
        [DataMember]
        protected readonly IAccessExtension AccessExtension;

        protected AccessBase(Permission permission, IAccessExtension extension)
        {
            Permission = permission;
            AccessExtension = extension;
        }

        public Permission Key
        {
            get
            {
                return Permission;
            }
        }

        public IAccessExtension Extension
        {
            get
            {
                return AccessExtension;
            }          
        }


        public bool Equals(IAccess<Permission> other)
        {
            return Permission.Equals(other);
        }

        #region IAccess<Permission,E> Members

        /// <summary>
        /// Intersect minimizes the access, intersect of a pos and neg => pos. Intersect of neg and neg => neg
        /// </summary>
        public virtual IAccess<Permission> Intersect(IAccess<Permission> target)
        {
            if (target.Negative != Negative)
            {
                var pos = target.Negative ? this : target;
                var neg = !target.Negative ? this : target;
                return pos.Make(pos.Key & (Permission.All ^ neg.Key), null);
            }
            if (target.Negative && Negative)
            {
                Make(target.Key | Permission, null);
            }
            return Make(target.Key & Permission, null);
        }

        public virtual bool IsSubSetOf(IAccess<Permission> target)
        {
            return (target.Key & Permission) == Permission;
        }

        /// <summary>
        /// Union is overwrites in the order.
        /// </summary>
        public virtual IAccess<Permission> Union(IAccess<Permission> target)
        {
            if (target.Negative != Negative)
            {
                if (Negative) //Ignore the first negative. E.g. Deny Write then Grant Write => Grant Write.
                    return Make(target.Key, null);
                if (target.Negative)
                    return Make(Key & (Permission.All ^ target.Key), null);
            }
            return Make(target.Key | Permission, null);
        }

        public abstract bool Negative { get; }
        #endregion

        #region IAccessFactory<Permission> Members

        public abstract IAccess<Permission> Make(Permission perm, IAccessExtension ext);

        #endregion

    }

}
