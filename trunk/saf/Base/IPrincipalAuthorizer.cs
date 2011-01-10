using System;

using System.Security.Principal;

namespace saf.Base
{
    public interface IPrincipalAuthorizer<T> 
    {
        int Order { get; set; }

        IAccess<T> AuthorizeByType(IPrincipal principal, Type type, Object instance);

        IAccess<T> AuthorizeByType(IPrincipal principal, Type type, Object instance, string property);
    }
}
