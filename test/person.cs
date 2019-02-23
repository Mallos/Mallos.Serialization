namespace Mallos.Serialization
{
    using System.Runtime.Serialization;

    public class Person : ISerializable
    {
        public static readonly Person Homer = new Person("Homer Simpson");

        public readonly string Name;

        public Person(string name)
        {
            this.Name = name;
        }

        public Person(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Name = info.GetString("Name");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
        }
    }
}
