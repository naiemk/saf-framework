using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IAccess<T, E>: IEquatable<IAccess<T,E>> where E : IAccessExtension
    {
        T Key { get; }
        E Extension { get; }
    }
}
