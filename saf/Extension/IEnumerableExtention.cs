using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using saf.Authorization.Management;
using saf.Authorization;

namespace saf.Extension
{
    public static class IEnumerableExtension
    {
        /// <summary>
        /// Filters collection: Retrieves only authorized objects. In case of partially authorized objects, scraps all unauthorized properties
        /// </summary>
        public static IEnumerable<Tuple<T, AuthorizationToken>> FilterAuthorized<T>(this IEnumerable<T> list, IPrincipal principal)
        {
            //Get authorization token for every single object in the list
            foreach (var l in list)
            {
                yield return new Tuple<T, AuthorizationToken>(l, AuthorizationHelper.GetAuthorizationToken(typeof(T), l, principal));
            }
        }
    }
}
