using System;
using saf.Base;

namespace saf.Providers
{
    public class SelfMetadata : IMetadataClass
    {
        public Type GetMetadataType(Type type)
        {
            return type;
        }
    }
}
