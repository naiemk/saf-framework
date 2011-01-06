using System;
using System.Linq;
using saf.Base;
using System.Security.Principal;
using saf.Authorization;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class DenyAttribute : Attribute, IPrincipalAuthorizer<Permission>
    {
        public String[] Roles;
        public Permission Permission;


        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //If the principle is in roles, deny permission from it

            return Roles.Any(principal.IsInRole) ? new DenyAccess(Permission, new DenyAccessExtension())
                : null;
        }

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {

            return AuthorizeByType(principal, type, null);
        }
    }
}
