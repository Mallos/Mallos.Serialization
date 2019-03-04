namespace Mallos.Serialization.Adaptors
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class JsonAdaptor : SerializerAdaptor
    {
        public JsonAdaptor(IEnumerable<Type> knownTypes)
            : base(knownTypes)
        {

        }

        public override T Deserialize<T>(Stream stream)
        {
            throw new NotImplementedException();
        }

        public override T DeserializeContent<T>(string value)
        {
            throw new NotImplementedException();
        }

        public override byte[] Serialize<T>(T value)
        {
            throw new NotImplementedException();
        }

        public override void Serialize<T>(T value, Stream stream)
        {
            throw new NotImplementedException();
        }

        public override string SerializeContent<T>(T value)
        {
            throw new NotImplementedException();
        }
    }
}
