using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IAccess<TA, TE>: IEquatable<IAccess<TA,TE>> where TE : IAccessExtension
    {
        TA Key { get; }
        TE Extension { get; }
        IAccess<TA, TE> Intersect(IAccess<TA, TE> target);
        IAccess<TA, TE> Union(IAccess<TA, TE> target);
        bool IsSubSetOf(IAccess<TA, TE> target);
        bool Negative { get; }
    }
}
