namespace Mallos.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;

    public enum SerializeFormat
    {
        Json,
        Xml
    }

    public class Serializer
    {
        public SerializeFormat Format { get; private set; }

        public SerializerStream SerializerStream { get; private set; }

        public Serializer(SerializeFormat format = SerializeFormat.Json, IEnumerable<Type> knownTypes = null)
        {
            this.Format = format;
            this.SerializerStream = CreateSerializer(format, knownTypes);
        }

        public void Serialize<T>(string filepath, T value, bool binary = true)
        {
            if (binary)
            {
                using (var fileStream = new FileStream(filepath, FileMode.Create))
                using (Stream stream = new GZipStream(fileStream, CompressionMode.Compress))
                {
                    SerializerStream.Serialize(value, stream);
                }
            }
            else
            {
                var content = SerializerStream.SerializeContent(value);
                File.WriteAllText(filepath, content);
            }
        }

        public T Deserialize<T>(string filepath, bool binary = true)
        {
            if (!File.Exists(filepath))
            {
                throw new FileNotFoundException($"File doesn't exists. (${filepath})");
            }

            if (binary)
            {
                var bytes = DeserializeBinary(filepath);
                return SerializerStream.Deserialize<T>(bytes);
            }
            else
            {
                var content = File.ReadAllText(filepath);
                return SerializerStream.DeserializeContent<T>(content);
            }
        }

        private static byte[] DeserializeBinary(string filepath)
        {
            using (var memoryStream = new MemoryStream())
            using (var fileStream = new FileStream(filepath, FileMode.Open))
            {
                using (var stream = new GZipStream(fileStream, CompressionMode.Decompress))
                {
                    stream.CopyTo(memoryStream);
                }
                return memoryStream.ToArray();
            }
        }

        private static SerializerStream CreateSerializer(SerializeFormat format, IEnumerable<Type> knownTypes)
        {
            switch (format)
            {
                default:
                case SerializeFormat.Xml: return new SerializerStreamXml(knownTypes: knownTypes);
                case SerializeFormat.Json: return new SerializerStreamJson(knownTypes);
            }
        }
    }
}
