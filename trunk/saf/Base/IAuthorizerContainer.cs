
using System.Collections.Generic;

namespace saf.Base
{
    public interface IAuthorizerContainer<T>
    {
        int Order { get; set; }
        IEnumerable<IPrincipalAuthorizer<T>> GetAuthorizers();
    }
}
