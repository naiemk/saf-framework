using System;
using saf.Base;
using System.Security.Principal;
using saf.Authorization;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class |  AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class AuthorizationCustomAttribute : Attribute, IPrincipalAuthorizer<Permission>
    {
        public string Method { get; set; }
        public Type CustomType { get; set; }

        /// <summary>
        /// Returns the authorization result. This method will not set the PartialAccessExtension
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="type">Must be the actual type of entity, not metadata</param>
        /// <param name="instance">The entity instance</param>
        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //Run the custom authorizer
            var met = CustomType.GetMethod(Method);
            var perm = (Permission)met.Invoke(null, new[] { principal, instance });
            return new GrantAccess(perm, null);
        }

        public IAccess<Permission> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {
            //Run the custom authorizer
            var met = CustomType.GetMethod(Method);
            var prop = type.GetProperty(property);
            var perm = (Permission)met.Invoke(null, new[] { principal, instance, prop.GetValue(instance, null) });
            return new GrantAccess(perm, null);
        }
    }
}
