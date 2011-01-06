
namespace saf.Base
{
    public interface IAccessFactory<TP> 
    {
        IAccess<TP> Make(TP perm, IAccessExtension ext);
    }
}
