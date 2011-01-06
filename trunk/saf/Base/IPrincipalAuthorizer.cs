using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace saf.Base
{
    internal interface IPrincipalAuthorizer<T> 
    {
        IAccess<T, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, Object instance);

        IAccess<T, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, Object instance, string property);
    }
}
