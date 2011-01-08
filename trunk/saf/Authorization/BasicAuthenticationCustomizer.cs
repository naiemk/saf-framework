using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;

namespace saf.Authorization
{
    public class BasicAuthenticationCustomizer<T> : IAuthenticationCustomizer<T>
    {
        public T CustomMethod(Type customType, string method, System.Security.Principal.IPrincipal principal, object instance)
        {
            var met = customType.GetMethod(method);
            return (T)met.Invoke(null, new[] { principal, instance });
        }

        public T CustomMethod(Type customType, string method, System.Security.Principal.IPrincipal principal, object instance, string property)
        {
            var met = customType.GetMethod(method);
            var prop = instance.GetType().GetProperty(property);
            return (T)met.Invoke(null, new[] { principal, instance, prop.GetValue(instance, null)});
        }

    }
}
