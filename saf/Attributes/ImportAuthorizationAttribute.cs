using System;
using System.Collections.Generic;
using System.Linq;
using saf.Base;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class ImportAuthorizationAttribute : Attribute, IAuthorizerContainer<Permission>
    {
        public Type SourceType { get; set; }

        public int Order { get; set; }

        public IEnumerable<IPrincipalAuthorizer<Permission>> GetAuthorizers()
        {
            if (SourceType == null)
                throw new ArgumentNullException("SourceType");
            var childs = SourceType.GetCustomAttributes(typeof (IAuthorizerContainer<Permission>), false)
                .OfType<IAuthorizerContainer<Permission>>()
                .OrderBy(c => c.Order);
            return childs.SelectMany(x => x.GetAuthorizers());
        }
    }
}
