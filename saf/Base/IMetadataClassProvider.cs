using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IMetadataClassProvider
    {
        Type GetMetadataType(Type type);
    }
}
