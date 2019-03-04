namespace Mallos.Serialization.Adaptors.Json
{
    using System;

    public class JsonStreamReader : SerializationStream
    {
        public JsonStreamReader(JsonDocument document)
        {

        }

        public override void AddValue(string name, object value, Type type)
        {
            throw new NotSupportedException();
        }

        public override object GetValue(string name, Type type)
        {

        }
    }
}
