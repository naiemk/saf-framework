
using System.Collections.Generic;

namespace saf.Base
{
    public interface IAuthorizerContainer<T>
    {
        IEnumerable<IPrincipalAuthorizer<T>> GetAuthorizers();
    }
}
