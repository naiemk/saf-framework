using System;
using System.Collections.Generic;
using saf.Base;
using System.Security.Principal;
using saf.Authorization;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class |  AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class AuthorizationCustomAttribute : Attribute, IPrincipalAuthorizer<Permission>, IAuthorizerContainer<Permission>
    {
        public int Order { get; set; }
        public string Method { get; set; }
        public Type CustomType { get; set; }
        private IAuthenticationCustomizer<Permission?> _authorizationCustomizer;
        /// <summary>
        /// Returns the authorization result. This method will not set the PartialAccessExtension
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="type">Must be the actual type of entity, not metadata</param>
        /// <param name="instance">The entity instance</param>
        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //Run the custom authorizer
            var perm = _authorizationCustomizer.CustomMethod(CustomType ?? type, Method, principal, instance);
            return perm != null ? new GrantAccess(((Permission?)perm).Value, null) : null;
        }

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {            
            var perm = _authorizationCustomizer.CustomMethod(CustomType ?? type, Method, principal, instance, property);
            return perm.HasValue ? new GrantAccess(perm.Value, null) : null;
        }

        public AuthorizationCustomAttribute()
        {
            _authorizationCustomizer = new BasicAuthenticationCustomizer<Permission?>();
        }

        public IEnumerable<IPrincipalAuthorizer<Permission>> GetAuthorizers()
        {
            yield return this;
        }
    }
}
