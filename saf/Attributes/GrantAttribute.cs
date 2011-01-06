using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;
using System.Security.Principal;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class |  AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class GrantAttribute : Attribute, IPrincipalAuthorizer<Permission>
    {
        public String[] Roles;
        public Permission Permission;


        public IAccess<Permission, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //If the principle is in roles, give it the permission

            return Roles.Any(r => principal.IsInRole(r)) ? (IAccess<Permission, IAccessExtension>)new ObjectAccess(Permission, null) 
                : (IAccess<Permission, IAccessExtension>) null;
        }

        public IAccess<Permission, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {

            return AuthorizeByType(principal, type, null);
        }
    }
}
