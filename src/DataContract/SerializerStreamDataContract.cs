﻿namespace Mallos.Serialization.DataContract
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Xml;

    public abstract class SerializerStreamDataContract<TSerializer> : SerializerStream
        where TSerializer : XmlObjectSerializer
    {
        protected SerializerStreamDataContract(IEnumerable<Type> knownTypes)
            : base(knownTypes ?? SerializerHelper.GetSerializableTypes())
        {

        }

        public override T Deserialize<T>(Stream stream)
        {
            using (var reader = XmlDictionaryReader.CreateBinaryReader(stream,
                XmlDictionaryReaderQuotas.Max))
            {
                var ser = CreateSerializer<T>();
                return ReadObject<T>(ser, reader);
            }
        }

        public override T DeserializeContent<T>(string value)
        {
            var byteArray = Encoding.UTF8.GetBytes(value);
            using (var stream = new MemoryStream(byteArray))
            {
                var serializer = CreateSerializer<T>();
                return (T)serializer.ReadObject(stream);
            }
        }

        public override byte[] Serialize<T>(T value)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
                {
                    var serializer = CreateSerializer<T>();
                    WriteObject(serializer, writer, value);
                }
                return stream.ToArray();
            }
        }

        public override void Serialize<T>(T value, Stream stream)
        {
            using (var writer = XmlDictionaryWriter.CreateBinaryWriter(stream))
            {
                var serializer = CreateSerializer<T>();
                WriteObject(serializer, writer, value);
            }
        }

        public override string SerializeContent<T>(T value)
        {
            using (var stream = new MemoryStream())
            {
                var serializer = CreateSerializer<T>();
                serializer.WriteObject(stream, value);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }

        protected virtual T ReadObject<T>(TSerializer serializer, XmlDictionaryReader stream)
        {
            return (T)serializer.ReadObject(stream, true);
        }

        protected virtual void WriteObject<T>(TSerializer serializer,
            XmlDictionaryWriter stream, T value)
        {
            serializer.WriteObject(stream, value);
        }

        protected virtual TSerializer CreateSerializer<T>()
        {
            if (KnownTypes != null)
            {
                return (TSerializer)Activator.CreateInstance(typeof(TSerializer),
                    typeof(T), KnownTypes);
            }
            else
            {
                return (TSerializer)Activator.CreateInstance(typeof(TSerializer), typeof(T));
            }
        }
    }
}
