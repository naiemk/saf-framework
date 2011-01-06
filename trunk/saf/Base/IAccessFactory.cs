
namespace saf.Base
{
    interface IAccessFactory<TP, TE> where TE:IAccessExtension
    {
        IAccess<TP, TE> Make(TP perm, TE ext);
    }
}
