using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IAccess<TA> : IEquatable<IAccess<TA>>, IAccessFactory<Permission> 
    {
        TA Key { get; }
        IAccessExtension Extension { get; }
        IAccess<TA> Intersect(IAccess<TA> target);
        IAccess<TA> Union(IAccess<TA> target);
        bool IsSubSetOf(IAccess<TA> target);
        bool Negative { get; }
    }
}
