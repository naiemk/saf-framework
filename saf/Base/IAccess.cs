using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IAccess< TA, out TE> : IEquatable<IAccess<TA, IAccessExtension>> where TE : IAccessExtension
    {
        TA Key { get; }
        TE Extension { get; }
        IAccess<TA, TE> Intersect(IAccess<TA, IAccessExtension> target);
        IAccess<TA, TE> Union(IAccess<TA, IAccessExtension> target);
        bool IsSubSetOf(IAccess<TA, IAccessExtension> target);
        bool Negative { get; }
    }
}
