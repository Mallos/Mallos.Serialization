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
            info.AddValue("Name", Name);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            
            return base.Equals(obj) &&
                   (obj as Person).Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Name.GetHashCode();
        }
    }
}
