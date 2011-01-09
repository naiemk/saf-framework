using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using saf.Base;
using saf.Common;

namespace saf.Extraction
{
    public static class PermissionHelper
    {
        public static IAccess<TP> GetObjectLevelPremission<TP>
            (IAuthorizationRuleProvider<TP> authorizationProvider, Type type, object instance, IPrincipal principal)
        {
            var authorizers = authorizationProvider.GetAuthorizers(type);

            var rv =
                authorizers.Select(a => a.AuthorizeByType(principal, type, instance))
                .Where(p => p != null).Select(p => p)
                .Union();

            return rv;
        }

        public static IDictionary<String, IAccess<TP>> GetPropertyLevelPremissions<TP>
           (IAuthorizationRuleProvider<TP> authorizationRuleProvider, IAccess<TP> reflectedPermission, Type type, object instance, IPrincipal principal)
        {
            var rv = new Dictionary<string, IAccess<TP>>();

            var propAuthorizers = authorizationRuleProvider.GetPropertyAuthorizers(type);

            foreach (var propAuthorizer in propAuthorizers)
            {
                var propPerm = GetPropertyPermissions<TP>(propAuthorizer.Key, propAuthorizer.Value, type, instance, principal);
                if (propPerm != null)
                    rv.Add(propAuthorizer.Key, reflectedPermission != null ? 
                        reflectedPermission.Intersect(propPerm) : propPerm);
            }

            return rv;
        }

        internal static IAccess<TP> GetPropertyPermissions<TP>(string name, IEnumerable<IPrincipalAuthorizer<TP>> authorizers, Type reflectedType, object instance, IPrincipal principal)
        {
            //Get all attributes for the type

            return
                authorizers.Select(a => a.AuthorizeByType(principal, reflectedType, instance, name))
                .Where(p => p != null).Select(p => p)
                .Union();
        }
    }
}
