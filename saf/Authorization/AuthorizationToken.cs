using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using saf.Base;

namespace saf.Authorization
{
    [DataContract]
    public class AuthorizationToken
    {
        [DataMember]
        //Tuple of propertyname visible editable
        private readonly IList<Tuple<string, bool, bool>> _properties;

        [DataMember] 
        private readonly TypeAuthorizationToken _parentAuthorizationToken;

        public AuthorizationToken(TypeAuthorizationToken parent, IEnumerable<Tuple<string, bool, bool>> props)
        {
            _properties = props.ToList();
            _parentAuthorizationToken = parent;
        }

        public bool Visible(string property = null)
        {
            if (property == null)
                return _parentAuthorizationToken.Visible; 
            return _properties.Where(p => p.Item1 == property).Select(p => (bool?)p.Item2).FirstOrDefault() ??
                _parentAuthorizationToken.Visible;
        }

        public bool Editable(string property = null)
        {
            if (property == null)
                return _parentAuthorizationToken.Editable;
            return _properties.Where(p => p.Item1 == property).Select(p => (bool?) p.Item2).FirstOrDefault() ??
                   _parentAuthorizationToken.Editable;
        }

        public static AuthorizationToken Make( IAccess<Permission> typeAccess, 
            IDictionary<string,IAccess<Permission>> propsAccess )
        {
            return typeAccess.Key > 0
                       ? //Has role
                   new AuthorizationToken(
                       TypeAuthorizationToken.Make(typeAccess),
                       propsAccess.Select(kv => new Tuple<String, bool, bool>
                                                    (
                                                    kv.Key,
                                                    kv.Value.Key.HasFlag(Permission.View) ||
                                                    kv.Value.Key.HasFlag(Permission.Own),
                                                    kv.Value.Key.HasFlag(Permission.Edit) ||
                                                    kv.Value.Key.HasFlag(Permission.Own)
                                                    )
                           ).ToList(),
                       typeAccess.Key.HasFlag(Permission.Edit) || typeAccess.Key.HasFlag(Permission.Own),
                       )
                       : null;
        }

    }
}
