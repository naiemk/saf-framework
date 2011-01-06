﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using saf.Base;
using saf.Extension;

namespace saf.Extraction
{
    internal static class PermissionHelper
    {
        internal static IAccess<Permission> GetObjectLevelPremission
            (IMetadataClassProvider metadataProvider, Type type, object instance, IPrincipal principal)
        {
            var meta = metadataProvider.GetMetadataType(type);

            //Get all attributes for the type
            var authorizers = meta.GetCustomAttributes(false).OfType<IPrincipalAuthorizer<Permission>>();

            var rv =
                authorizers.Select(a => a.AuthorizeByType(principal, type, instance))
                .Where(p => p != null).Select(p => p)
                .Union();

            return rv;
        }

        internal static IDictionary<String, IAccess<TP>> GetPropertyLevelPremissions<TP>
           (IMetadataClassProvider metadataProvider, IAccess<TP> reflectedPermission, Type type, object instance, IPrincipal principal)
        {
            var meta = metadataProvider.GetMetadataType(type);

            //Get all properties
            var props = meta.GetProperties();
            var rv = new Dictionary<string, IAccess<TP>>();

            foreach (var propertyInfo in props)
            {
                var propPerm = GetPropertyPermissions<TP>(propertyInfo, instance, principal);
                if (propPerm != null)
                    rv.Add(propertyInfo.Name, reflectedPermission != null ? 
                        reflectedPermission.Intersect(propPerm) : propPerm);
            }

            return rv;
        }

        internal static IAccess<TP> GetPropertyPermissions<TP>(PropertyInfo propertyInfo, object instance, IPrincipal principal)
        {
            //Get all attributes for the type
            var authorizers = propertyInfo.GetCustomAttributes(false).OfType<IPrincipalAuthorizer<TP>>();

            var rv =
                authorizers.Select(a => a.AuthorizeByType(principal, propertyInfo.ReflectedType, instance, propertyInfo.Name))
                .Where(p => p != null).Select(p => p)
                .Union();

            return rv;
        }
    }
}