namespace Mallos.Serialization.Adaptors.Json
{
    using System;

    public class JsonStreamWriter : SerializationStream
    {
        public JsonStreamWriter(IBufferWriter<byte> output)
        {
            var json = new Utf8JsonWriter(output, state: default);
        }

        public override void AddValue(string name, object value, Type type)
        {

        }

        public override object GetValue(string name, Type type)
        {
            throw new NotSupportedException();
        }
    }
}
