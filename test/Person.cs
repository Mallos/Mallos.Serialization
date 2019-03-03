namespace Mallos.Serialization
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class Person : ISerializable
    {
        public static readonly Person Homer = new Person("Homer Simpson");

        public readonly string Name;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            this.Name = info.GetString("Name");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name, typeof(string));
        }

        public override string ToString() => $"Person Name: {Name}";
    }
}
