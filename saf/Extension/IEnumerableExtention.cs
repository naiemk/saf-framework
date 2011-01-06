using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using saf.Authorization.Management;
using saf.Authorization;
using saf.Base;

namespace saf.Extension
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Filters collection: Retrieves only authorized objects. In case of partially authorized objects, scraps all unauthorized properties
        /// </summary>
        public static IEnumerable<Tuple<T, AuthorizationToken>> FilterAuthorized<T>
            (this IEnumerable<T> list, IMetadataClassProvider meta, IPrincipal principal)
        {
            //Get authorization token for every single object in the list
            return list.Select(l => 
                new Tuple<T, AuthorizationToken>(l, AuthorizationHelper.GetAuthorizationToken(meta, typeof(T), l, principal)));
        }

        public static IAccess<TP, TE> Intersect<TP, TE>(this IEnumerable<IAccess<TP, TE>> list) where  TE: IAccessExtension
        {
            return list.Aggregate(default(IAccess<TP, TE>), (current, access) => current == null ? 
                ((IAccessFactory<TP, TE>) access).Make(access.Key, access.Extension) : current.Intersect(access));
        }

        public static IAccess<TP, TE> Union<TP, TE>(this IEnumerable<IAccess<TP, TE>> list) where TE : IAccessExtension
        {
            return list.Aggregate(default(IAccess<TP, TE>), (current, access) => current == null ?
                ((IAccessFactory<TP, TE>)access).Make(access.Key, access.Extension) : current.Intersect(access));
        }
    }
}
