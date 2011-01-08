using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;

namespace saf.Common
{
    internal static class ExtensionHelpers
    {
        public static IAccess<TP> Intersect<TP>(this IEnumerable<IAccess<TP>> list)
        {
            return list.Aggregate(default(IAccess<TP>), (current, access) => current == null ?
                ((IAccessFactory<TP>)access).Make(access.Key, access.Extension) : current.Intersect(access));
        }

        public static IAccess<TP> Union<TP>(this IEnumerable<IAccess<TP>> list)
        {
            return list.Aggregate(default(IAccess<TP>), (current, access) => current == null ?
                ((IAccessFactory<TP>)access).Make(access.Key, access.Extension) : current.Union(access));
        }
    }
}
