using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public class DenyAccess : AccessBase
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

        public override bool Negative
        {
            get { return true; }
        }


        public DenyAccess(Permission per, IAccessExtension ext) : base(per, ext) { }

        public override IAccess<Permission> Make(Permission perm, IAccessExtension ext)
        {
            return new DenyAccess(perm, new DenyAccessExtension());
        }
    }
}
