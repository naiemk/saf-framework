using System;
using System.Linq;
using saf.Authorization;
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

            return Roles.Any(principal.IsInRole) ? (IAccess<Permission, IsPartialAccessExtension>)new ObjectAccess(Permission, null) 
                : (IAccess<Permission, IAccessExtension>) null;
        }

        public IAccess<Permission, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {

            return AuthorizeByType(principal, type, null);
        }
    }
}
