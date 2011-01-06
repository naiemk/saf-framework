
namespace saf.Base
{
    interface IAccessFactory<TP, out TE> where TE:IAccessExtension
    {
        IAccess<TP, TE> Make(TP perm, IAccessExtension ext);
    }
}
