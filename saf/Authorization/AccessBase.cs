using System;
using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public abstract class AccessBase<TE>: IAccess<Permission, TE>, IAccessFactory<Permission, TE> where TE:IAccessExtension
    {
        [DataMember]
        protected readonly Permission Permission;
        [DataMember]
        protected readonly TE AccessExtension;
        
        protected AccessBase(Permission permission, TE extension)
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

        public TE Extension
        {
            get
            {
                return AccessExtension;
            }          
        }

        public bool Equals(IAccess<Permission, TE> other)
        {
            return Permission.Equals(other);
        }

        #region IAccess<Permission,E> Members

        public virtual IAccess<Permission, TE> Intersect(IAccess<Permission, TE> target)
        {
            return  Make(target.Key & this.Permission, default(TE));
        }

        public virtual bool IsSubSetOf(IAccess<Permission, TE> target)
        {
            return (target.Key & Permission) == Permission;
        }

        public virtual IAccess<Permission, TE> Union(IAccess<Permission, TE> target)
        {
            return Make(target.Key | this.Permission, default(TE));
        }

        public virtual bool Negative
        {
            get { return false; }
        }
        #endregion

        #region IAccessFactory<Permission,TE> Members

        public abstract IAccess<Permission, TE> Make(Permission perm, TE ext);

        #endregion

    }
}
