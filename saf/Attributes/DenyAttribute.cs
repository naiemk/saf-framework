﻿using System;
using System.Linq;
using saf.Base;
using System.Security.Principal;
using saf.Authorization;

namespace saf.Attributes
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class DenyAttribute : Attribute, IPrincipalAuthorizer<Permission>
    {
        public String[] Roles;
        public Permission Permission;


        public IAccess<Permission, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, object instance)
        {
            //If the principle is in roles, deny permission from it

            return Roles.Any(r => principal.IsInRole(r)) ? (IAccess<Permission, IAccessExtension>)new DenyAccess(Permission, new DenyAccessExtension())
                : (IAccess<Permission, IAccessExtension>)null;
        }

        public IAccess<Permission, IAccessExtension> AuthorizeByType(IPrincipal principal, Type type, object instance, string property)
        {

            return AuthorizeByType(principal, type, null);
        }
    }
}