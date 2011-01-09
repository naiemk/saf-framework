﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace saf.Authorization.Extension
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Filters collection: Retrieves only authorized objects. In case of partially authorized objects, scraps all unauthorized properties
        /// </summary>
        public static IEnumerable<Tuple<T, AuthorizationToken>> FilterUnAuthorizedWithToken<T>
            (this IEnumerable<T> list, AuthorizationContext context)
        {
            //Get authorization token for every single object in the list
            return list.Select(l => 
                new Tuple<T, AuthorizationToken>(l, context.GetAuthorizationToken(l)))
                .Where(t => t.Item2 != null )
                .Select(ScrapUnAuthorized );
        }

        public static IEnumerable<T> FilterUnAuthorized<T>(this IEnumerable<T> list, AuthorizationContext context)
        {
            return FilterUnAuthorizedWithToken(list, context).Select(t => t.Item1);
        }

        private static Tuple<T, AuthorizationToken> ScrapUnAuthorized<T>(Tuple<T, AuthorizationToken> t)
        {
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                if (!t.Item2.Visible(prop.Name) && prop.CanWrite )
                {
                    prop.SetValue(t.Item1, prop.GetType().IsValueType ? Activator.CreateInstance(prop.GetType()) : null, null);
                }
            }
            return t;
        }

    }
}
