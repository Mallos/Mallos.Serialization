namespace Mallos.Serialization
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class Employee : ISerializable
    {
        public static readonly Employee Homer = new Employee(new Person("Homer Simpson"));

        public readonly Person Person;

        public Employee(Person person)
        {
            this.Person = person;
        }

        public Employee(SerializationInfo info, StreamingContext context)
        {
            this.Person = info.GetValue<Person>("Person");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Person", Person, typeof(Person));
        }
    }
}
