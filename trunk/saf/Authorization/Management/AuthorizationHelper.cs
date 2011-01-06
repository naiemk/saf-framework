using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using saf.Base;

namespace saf.Authorization.Management
{
    public static class AuthorizationHelper
    {
        public static AuthorizationToken GetAuthorizationToken(Type type, object instance, IPrincipal principal)
        {
            //Get principal permissions on the instance
            //Generate tokens
            return new AuthorizationToken();
        }

        public static bool CanUpdate(Type type, object instance, IPrincipal principal)
        {
            return false;
        }

        public static bool CanInsert(Type type, object instance, IPrincipal principal)
        {
            return false;
        }

        public static bool CanDelete(Type type, object instance, IPrincipal principal)
        {
            return false;
        }

        private static IEnumerable<IAccess<Permission, IAccessExtension>> GetObjectLevelPremission
            (IMetadataClass metadataProvider, Type type, object instance, IPrincipal principal)
        {
            var meta = metadataProvider.GetMetadataType(type);

            //Run all attributes for the type
            var authorizers = meta.GetCustomAttributes(false).OfType <IPrincipalAuthorizer<Permission>>();

            var rv =
                authorizers.Select(a => a.AuthorizeByType(principal, type, instance)).Where(p => p != null).Select(p => p);

            return rv;
        }

        /// <summary>
        /// Aggregate all permissions and generate a token
        /// </summary>
        private static AuthorizationToken AuthorizationTokenFromPermission(IEnumerable<IAccess<Permission, IAccessExtension>> list)
        {
            return null;
        }
    }
}
