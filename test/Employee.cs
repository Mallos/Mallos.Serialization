namespace Mallos.Serialization
{
    public class Employee : ISerializable
    {
        public readonly Person Person;
        public readonly string Title;

        public Employee(Person person, string title)
        {
            this.Person = person;
            this.Title = title;
        }

        public Employee(SerializationStream stream)
        {
            this.Person = stream.GetValue<Person>("Person");
            this.Title = stream.GetString("Title");
        }

        public void GetObjectData(SerializationStream stream)
        {
            stream.AddValue("Person", Person);
            stream.AddString("Title", Title);
        }

        public override string ToString() => $"Employee<Person: {Person}, Title: {Title}>";
    }
}
