using System;
using System.Security.Principal;
using saf.Extraction;
using saf.Base;


namespace saf.Authorization.Management
{
    public static class AuthorizationHelper
    {
        public static AuthorizationToken GetAuthorizationToken(IMetadataClassProvider meta, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission(meta, type, instance, principal);
            return AuthorizationToken.Make(
                typePerm,
                PermissionHelper.GetPropertyLevelPremissions(meta, typePerm, type, instance, principal)
                );
        }

        public static bool CanUpdate(IMetadataClassProvider meta, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission(meta, type, instance, principal);
            return typePerm.Key.HasFlag(Permission.Edit) || typePerm.Key.HasFlag(Permission.Own);
        }

        public static bool CanInsert(IMetadataClassProvider meta, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission(meta, type, instance, principal);
            return typePerm.Key.HasFlag(Permission.Create) || typePerm.Key.HasFlag(Permission.Own);
        }

        public static bool CanDelete(IMetadataClassProvider meta, Type type, object instance, IPrincipal principal)
        {
            var typePerm = PermissionHelper.GetObjectLevelPremission(meta, type, instance, principal);
            return typePerm.Key.HasFlag(Permission.Delete) || typePerm.Key.HasFlag(Permission.Own);
        }
        
    }
}
