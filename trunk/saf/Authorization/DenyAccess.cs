using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public class DenyAccess : AccessBase<DenyAccessExtension>
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


        public DenyAccess(Permission per, DenyAccessExtension ext) : base(per, ext) { }
    }
}
