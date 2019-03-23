namespace Mallos.Serialization
{
    using System;
    using System.Runtime.Serialization;

    public static class SerializerExtensions
    {
        public static T GetValue<T>(this SerializationInfo info, string name)
        {
            return (T)info.GetValue(name, typeof(T));
        }

        public static void TryAddValue(this SerializationInfo info, string name, object obj)
        {
            if (obj != null)
            {
                info.AddValue(name, obj);
            }
        }

        public static void AddGuid(this SerializationInfo info, string name, Guid value) => info.AddValue(name, value.ToString(), typeof(string));
        public static Guid GetGuid(this SerializationInfo info, string name) => new Guid(info.GetString(name));
    }
}
