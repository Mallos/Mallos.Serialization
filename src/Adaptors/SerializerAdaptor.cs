namespace Mallos.Serialization.Adaptors
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public abstract class SerializerAdaptor
    {
        public readonly IEnumerable<Type> KnownTypes;

        protected SerializerAdaptor(IEnumerable<Type> knownTypes)
        {
            this.KnownTypes = knownTypes.Concat(SerializerHelper.DependencyTypes());
        }

        public T Deserialize<T>(byte[] value)
        {
            using (var stream = new MemoryStream(value))
            {
                return Deserialize<T>(stream);
            }
        }

        public abstract T Deserialize<T>(Stream stream);
        public abstract T DeserializeContent<T>(string value);

        public abstract byte[] Serialize<T>(T value);
        public abstract void Serialize<T>(T value, Stream stream);
        public abstract string SerializeContent<T>(T value);
    }
}
