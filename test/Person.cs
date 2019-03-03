namespace Mallos.Serialization
{
    public class Person : ISerializable
    {
        public readonly string Name;
        public readonly int Age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(SerializationStream stream)
        {
            this.Name = stream.GetString("Name");
            this.Age = stream.GetInt32("Age");
        }

        public void GetObjectData(SerializationStream stream)
        {
            stream.AddString("Name", Name);
            stream.AddInt32("Age", Age);
        }

        public override string ToString() => $"Person<Name: {Name}, Age: {Age}>";
    }
}
