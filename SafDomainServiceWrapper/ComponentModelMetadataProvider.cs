using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using saf.Base;

namespace SafDomainServiceWrapper
{
    public class ComponentModelMetadataClassProvider : IMetadataClassProvider
    {
        public Type GetMetadataType(Type type)
        {
            return type.GetCustomAttributes(false).OfType<MetadataTypeAttribute>().FirstOrDefault().MetadataClassType;
        }
    }
}
