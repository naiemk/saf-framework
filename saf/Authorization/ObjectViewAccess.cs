﻿using saf.Base;

namespace saf.Authorization
{
    public class ObjectViewAccess : AccessBase
    {

        public bool Visible
        {
            get
            {
                return Permission.HasFlag(Permission.View) || Permission.HasFlag(Permission.Own);
            }
        }

        public bool Editable
        {
            get
            {
                return Permission.HasFlag(Permission.Edit) || Permission.HasFlag(Permission.Own);
            }
        }

        public ObjectViewAccess(Permission perm) : base(perm, null) { }


        public override bool Negative
        {
            get { return true; }
        }

        public override IAccess<Permission> Make(Permission perm, IAccessExtension ext)
        {
            return new ObjectViewAccess(perm);
        }
    }
}
