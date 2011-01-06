using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    public class ObjectViewAccess : AccessBase<IAccessExtension>
    {

        public bool Visible
        {
            get
            {
                return _permission.HasFlag(Permission.View) || _permission.HasFlag(Permission.Own);
            }
        }

        public bool Editable
        {
            get
            {
                return _permission.HasFlag(Permission.Edit) || _permission.HasFlag(Permission.Own);
            }
        }

        public ObjectViewAccess(Permission perm) : base(perm, null) { }

    }
}
