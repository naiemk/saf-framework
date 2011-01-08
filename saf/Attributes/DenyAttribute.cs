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
        public Type ConditionType;
        public string Condition;

        private IAuthenticationCustomizer<bool> _condition;

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //If the principle is in roles, deny permission from it

            return Roles.Any(principal.IsInRole) &&
                    _condition.CustomMethod(ConditionType ?? type, Condition, principal, instance)
                    ? new DenyAccess(Permission, new DenyAccessExtension())
                : null;
        }

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {

            return Roles.Any(principal.IsInRole) &&
                    _condition.CustomMethod(ConditionType ?? type, Condition, principal, instance, property)
                    ? new DenyAccess(Permission, new DenyAccessExtension())
                : null;
        }

        public DenyAttribute()
        {
            _condition = new BasicAuthenticationCustomizer<bool>();
        }
    }
}
