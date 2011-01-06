using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace saf.Base
{
    public interface IMetadataClass
    {
        Type GetMetadataType(Type type);
    }
}
