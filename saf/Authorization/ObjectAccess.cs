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
                return _permission.HasFlag(Permission.View);
            }
        }
        public bool Edit
        {
            get
            {
                return _permission.HasFlag(Permission.Edit);
            }
        }
        public bool Create
        {
            get
            {
                return _permission.HasFlag(Permission.Create);
            }
        }
        public bool Delete
        {
            get
            {
                return _permission.HasFlag(Permission.Delete);
            }
        }
        public bool Own
        {
            get
            {
                return _permission.HasFlag(Permission.Own);
            }
        }
        public bool PartialEdit
        {
            get
            {
                return _accessExtension.IsPartialEdit;
            }
        }
        public bool PartialView
        {
            get
            {
                return _accessExtension.IsPartialView;
            }
        }

        public ObjectAccess(Permission per, IsPartialAccessExtension ext) : base(per, ext) { }
    }
}
