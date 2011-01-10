using System;
using System.Collections.Generic;
using System.Linq;
using saf.Base;

namespace saf.Attributes
{
    public class ImportAuthorizationAttribute : Attribute, IAuthorizerContainer<Permission>
    {
        public Type SourceType { get; set; }

        public IEnumerable<IPrincipalAuthorizer<Permission>> GetAuthorizers()
        {
            if (SourceType == null)
                throw new ArgumentNullException("SourceType");
            var childs = SourceType.GetCustomAttributes(typeof (IAuthorizerContainer<Permission>), false).OfType<IAuthorizerContainer<Permission>>();
            return childs.SelectMany(x => x.GetAuthorizers());
        }
    }
}
