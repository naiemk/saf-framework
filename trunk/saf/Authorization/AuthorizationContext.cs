using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;

namespace saf.Authorization
{
    public class AuthorizationContext
    {
        IMetadataClassProvider _metadataProvider;
        IAuthorizationRuleProvider<Permission> _authorizationRuleProvider;
        IPrincipalProvider _principalProvider;

        public AuthorizationContext(IMetadataClassProvider meta, IAuthorizationRuleProvider<Permission> rule, IPrincipalProvider pri)
        {
            _metadataProvider = meta;
            _authorizationRuleProvider = rule;
            _principalProvider = pri;
        }

        public AuthorizationToken GetAuthorizationToken(object instance)
        {
            return Management.AuthorizationHelper.GetAuthorizationToken
                (
                    _authorizationRuleProvider,
                    _metadataProvider.GetMetadataType(instance.GetType()),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

        public bool CanUpdate(object instance)
        {
            return Management.AuthorizationHelper.CanUpdate
                (
                    _authorizationRuleProvider,
                    _metadataProvider.GetMetadataType(instance.GetType()),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

        public bool CanInsert(object instance)
        {
            return Management.AuthorizationHelper.CanInsert
                (
                    _authorizationRuleProvider,
                    _metadataProvider.GetMetadataType(instance.GetType()),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

        public bool CanDelete(object instance)
        {
            return Management.AuthorizationHelper.CanDelete
                (
                    _authorizationRuleProvider,
                    _metadataProvider.GetMetadataType(instance.GetType()),
                    instance,
                    _principalProvider.GetCurrentPrincipal()
                );
        }

    }
}
