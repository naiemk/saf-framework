using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;

namespace saf.Base
{
    internal interface IAuthenticationCustomizer<T>
    {
        /// <summary>
        /// Should be used to run a custom method over a specific type by passing the instance
        /// </summary>
        T CustomMethod(Type customType, string method, IPrincipal principal, object instance);
        /// <summary>
        /// Should be used to run a custom method over a specific property of a specific type by passing the instance value and property value
        /// </summary>
        T CustomMethod(Type customType, string method, IPrincipal principal, object instance, string property);
    }
}
