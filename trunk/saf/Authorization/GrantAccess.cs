using saf.Base;
using System.Runtime.Serialization;

namespace saf.Authorization
{
    [DataContract]
    public class GrantAccess : AccessBase
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
        public bool? PartialEdit
        {
            get
            {
                return AccessExtension is IsPartialAccessExtension ?
                    (bool?)((IsPartialAccessExtension) AccessExtension).IsPartialEdit
                    : null;
            }
        }
        public bool? PartialView
        {
            get
            {
                return AccessExtension is IsPartialAccessExtension ?
                    (bool?)((IsPartialAccessExtension)AccessExtension).IsPartialView
                    : null;
            }
        }

        public GrantAccess(Permission per, IAccessExtension ext) : base(per, ext) { }


        public override bool Negative
        {
            get { return false; }
        }

        public override IAccess<Permission> Make(Permission perm, IAccessExtension ext)
        {
            return new GrantAccess(perm, ext as IsPartialAccessExtension);
        }
    }
}
