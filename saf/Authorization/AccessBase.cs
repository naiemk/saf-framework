using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public abstract class AccessBase<E>: IAccess<Permission, E> where E:IAccessExtension
    {
        [DataMember]
        protected readonly Permission _permission;
        [DataMember]
        protected readonly E _accessExtension;
        public AccessBase(Permission permission, E extension)
        {
            _permission = permission;
            _accessExtension = extension;
        }


        public Permission Key
        {
            get
            {
                return _permission;
            }
        }

        public E Extension
        {
            get
            {
                return _accessExtension;
            }          
        }

        public bool Equals(IAccess<Permission, E> other)
        {
            return _permission.Equals(other);
        }
    }
}
