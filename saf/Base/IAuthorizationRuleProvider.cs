using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IAuthorizationRuleProvider<T>
    {
        IEnumerable<IPrincipalAuthorizer<T>> GetAuthorizers(Type type);
        IDictionary<string, IEnumerable<IPrincipalAuthorizer<T>>> GetPropertyAuthorizers(Type type);
    }
}
