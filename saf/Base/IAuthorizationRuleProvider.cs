using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IAuthorizationRuleProvider<T>
    {
        public IEnumerable<IPrincipalAuthorizer<T>> GetAuthorizers(Type type);
        public IDictionary<string, IEnumerable<IPrincipalAuthorizer<TP>>> GetPropertyAuthorizers(Type type);
    }
}
