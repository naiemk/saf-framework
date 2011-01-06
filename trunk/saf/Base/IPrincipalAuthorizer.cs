using System;

using System.Security.Principal;

namespace saf.Base
{
    internal interface IPrincipalAuthorizer<T> 
    {
        IAccess<T> AuthorizeByType(IPrincipal principal, Type type, Object instance);

        IAccess<T> AuthorizeByType(IPrincipal principal, Type type, Object instance, string property);
    }
}
