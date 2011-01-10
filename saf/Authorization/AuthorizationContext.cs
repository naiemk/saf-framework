using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;

namespace saf.Authorization
{
    public class AuthorizationContext
    {
        readonly IAuthorizationRuleProvider<Permission> _authorizationRuleProvider;
        readonly IPrincipalProvider _principalProvider;

        public AuthorizationContext(IAuthorizationRuleProvider<Permission> rule, IPrincipalProvider pri)
        {
            _authorizationRuleProvider = rule;
            _principalProvider = pri;
        }

        public AuthorizationToken GetAuthorizationToken(object instance)
        {
            return Management.AuthorizationHelper.GetAuthorizationToken
                (
                    _authorizationRuleProvider,
                    instance.GetType(),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

        public bool CanUpdate(object instance)
        {
            return Management.AuthorizationHelper.CanUpdate
                (
                    _authorizationRuleProvider,
                    instance.GetType(),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

        public bool CanInsert(object instance)
        {
            return Management.AuthorizationHelper.CanInsert
                (
                    _authorizationRuleProvider,
                    instance.GetType(),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

        public bool CanDelete(object instance)
        {
            return Management.AuthorizationHelper.CanDelete
                (
                    _authorizationRuleProvider,
                    instance.GetType(),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

    }
}
