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
        private readonly bool _ediatable;
        private readonly bool _partiallyVisible;
        private readonly bool _partiallyEditable;

        public AuthorizationToken(IEnumerable<Tuple<string, bool, bool>> props, bool editable, bool partiallyVisible, bool partiallyEditable)
        {
            _properties = props.ToList();
            _ediatable = editable;
            _partiallyVisible = partiallyVisible;
            _partiallyEditable = partiallyEditable;
        }

        public bool? Visible(string property = null)
        {
            if (property == null)
                return true; //Always visible.
            return _properties.Where(p => p.Item1 == property).Select(p => (bool?)p.Item2).FirstOrDefault();
        }

        public bool? Editable(string property = null)
        {
            if (property == null)
                return _ediatable; //Always visible.
            return _properties.Where(p => p.Item1 == property).Select(p => (bool?)p.Item2).FirstOrDefault();
        }

        public bool? PartiallyEditable
        {
            get
            {
                return _partiallyEditable;
            }
        }

        public bool? PartiallyVisible
        {
            get
            {
                return _partiallyVisible;
            }
        }

        public static AuthorizationToken Make( IAccess<Permission, IAccessExtension> typeAccess, 
            IDictionary<string,IAccess<Permission, IAccessExtension>> propsAccess )
        {
            return new AuthorizationToken(
                propsAccess.Select( kv => new Tuple<String, bool, bool>
                    (
                        kv.Key,
                        kv.Value.Key.HasFlag(Permission.View) || kv.Value.Key.HasFlag(Permission.Own),
                        kv.Value.Key.HasFlag(Permission.Edit) || kv.Value.Key.HasFlag(Permission.Own) 
                    ) 
                ).ToList(),
                typeAccess.Key.HasFlag(Permission.Edit) || typeAccess.Key.HasFlag(Permission.Own),
                typeAccess.Extension is IsPartialAccessExtension ? 
                    ((IsPartialAccessExtension)typeAccess.Extension).IsPartialView : false,
                typeAccess.Extension is IsPartialAccessExtension ? 
                    ((IsPartialAccessExtension)typeAccess.Extension).IsPartialEdit : false
                );
        }

    }
}
