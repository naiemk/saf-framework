using System;
using System.Security.Principal;
using saf.Extraction;
using saf.Base;


namespace saf.Authorization.Management
{
    public static class AuthorizationHelper
    {
        public static AuthorizationToken GetAuthorizationToken(IAuthorizationRuleProvider<Permission> auth, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission<Permission>(auth, type, instance, principal);
            return AuthorizationToken.Make(
                typePerm,
                PermissionHelper.GetPropertyLevelPremissions<Permission>(auth, typePerm, type, instance, principal)
                );
        }

        public static bool CanUpdate(IAuthorizationRuleProvider<Permission> auth, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission<Permission>(auth, type, instance, principal);
            return typePerm.Key.HasFlag(Permission.Edit) || typePerm.Key.HasFlag(Permission.Own);
        }

        public static bool CanInsert(IAuthorizationRuleProvider<Permission> auth, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission<Permission>(auth, type, instance, principal);
            return typePerm.Key.HasFlag(Permission.Create) || typePerm.Key.HasFlag(Permission.Own);
        }

        public static bool CanDelete(IAuthorizationRuleProvider<Permission> auth, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission<Permission>(auth, type, instance, principal);
            return typePerm.Key.HasFlag(Permission.Delete) || typePerm.Key.HasFlag(Permission.Own);
        }
        
    }
}
