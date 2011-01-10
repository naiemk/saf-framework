using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;

namespace saf.Providers
{
    public class AttributeAuthorizationProvider<TP> : IAuthorizationRuleProvider<TP>
    {
        readonly IMetadataClassProvider _metadataClassProvider;

        public IEnumerable<IPrincipalAuthorizer<TP>> GetAuthorizers(Type type)
        {
            var meta = _metadataClassProvider.GetMetadataType(type);

            //Get all attributes for the type
            return meta.GetCustomAttributes(false).OfType<IPrincipalAuthorizer<TP>>();
        }

        public AttributeAuthorizationProvider(IMetadataClassProvider meta)
        {
            _metadataClassProvider = meta;
        }

        public IDictionary<string, IEnumerable<IPrincipalAuthorizer<TP>>> GetPropertyAuthorizers(Type type)
        {
            var meta = _metadataClassProvider.GetMetadataType(type);
            var props = meta.GetProperties();
            return props
                .Select( p => new {Name = p.Name, Auths = p.GetCustomAttributes(false).OfType<IPrincipalAuthorizer<TP>>().ToList()} )
                .Where( p => p.Auths != null && p.Auths.Count > 0 )
                .ToDictionary( p => p.Name, p => p.Auths.AsEnumerable() );
        }

        public Type GetCustomizer(Type type)
        {
            return _metadataClassProvider.GetMetadataType(type);
        }
    }
}
