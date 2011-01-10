using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using saf.Base;
using saf.Providers;

namespace SafDomainServiceWrapper
{
    public class RequiresPermissionAttribute : AuthorizationAttribute
    {
        public Permission Permission { get; set; }
        protected override AuthorizationResult IsAuthorized(System.Security.Principal.IPrincipal principal, AuthorizationContext authorizationContext)
        {
            var instance = authorizationContext.Instance;
            var rv = saf.Extraction.PermissionHelper.GetObjectLevelPremission(
                new AttributeAuthorizationProvider<Permission>(new ComponentModelMetadataClassProvider()),
                instance.GetType(), instance, principal);
            if (rv != null && (Permission & rv.Key) > 0)
                return AuthorizationResult.Allowed;
            return new AuthorizationResult("Access denied due to authorization restriction.");
        }
    }


}
