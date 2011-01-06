using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public class ObjectAccess : AccessBase<IsPartialAccessExtension>
    {
        public bool View
        {
            get
            {
                return Permission.HasFlag(Permission.View);
            }
        }
        public bool Edit
        {
            get
            {
                return Permission.HasFlag(Permission.Edit);
            }
        }
        public bool Create
        {
            get
            {
                return Permission.HasFlag(Permission.Create);
            }
        }
        public bool Delete
        {
            get
            {
                return Permission.HasFlag(Permission.Delete);
            }
        }
        public bool Own
        {
            get
            {
                return Permission.HasFlag(Permission.Own);
            }
        }
        public bool PartialEdit
        {
            get
            {
                return AccessExtension.IsPartialEdit;
            }
        }
        public bool PartialView
        {
            get
            {
                return AccessExtension.IsPartialView;
            }
        }

        public ObjectAccess(Permission per, IsPartialAccessExtension ext) : base(per, ext) { }


        public override IAccess<Permission, IsPartialAccessExtension> Make(Permission perm, IsPartialAccessExtension ext)
        {
            return new ObjectAccess(perm, ext);
        }
    }
}
