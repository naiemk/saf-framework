using System;
using System.Collections.Generic;
using System.Linq;
using saf.Authorization;
using saf.Base;
using System.Security.Principal;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class |  AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class GrantAttribute : Attribute, IPrincipalAuthorizer<Permission>, IAuthorizerContainer<Permission>
    {
        public String[] Roles;
        public Permission Permission;
        public const string WildChar = "*";
        public Type ConditionType;
        public string Condition;

        private readonly IAuthenticationCustomizer<bool> _condition;

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //If the principle is in roles, give it the permission

            return 
                    Roles.Any(r => principal.IsInRole(r) || r == WildChar) &&
                    (
                        _condition == null || String.IsNullOrEmpty(Condition) ||
                        _condition.CustomMethod(ConditionType ?? type, Condition, principal, instance)
                    )
                    ? new GrantAccess(Permission, null) 
                : null;
        }

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {
            return 
                Roles.Any(r => principal.IsInRole(r) || r == WildChar) &&
                    (
                        _condition == null || String.IsNullOrEmpty(Condition) ||
                        _condition.CustomMethod(ConditionType ?? type, Condition, principal, instance)
                    )
                    ? new GrantAccess(Permission, null)
                : null;
        }

        public GrantAttribute()
        {
            _condition = new BasicAuthenticationCustomizer<bool>();
        }

        public IEnumerable<IPrincipalAuthorizer<Permission>> GetAuthorizers()
        {
            yield return this;
        }
    }
}
