using System;
using saf.Base;

namespace saf.Providers
{
    public class SelfMetadata : IMetadataClassProvider
    {
        public Type GetMetadataType(Type type)
        {
            return type;
        }
    }
}
