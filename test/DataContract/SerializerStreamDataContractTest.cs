namespace Mallos.Serialization.DataContract
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class SerializerStreamDataContractTest : Test
    {
        public SerializerStreamDataContractTest(ITestOutputHelper output)
            : base(output)
        {

        }

        protected abstract SerializerStream CreateSerializer(
            IEnumerable<Type> types = null, IEnumerable<Assembly> assemblies = null
        );

<<<<<<< Updated upstream
        [Fact]
        public string Save()
        {
            var stream = CreateSerializer();

            var result = stream.SerializeContent(Person.Homer);
=======
        [Theory]
        [MemberData(nameof(PersonData))]
        public string Save(Person person)
        {
            var stream = CreateSerializer();

            var result = stream.SerializeContent(person);
>>>>>>> Stashed changes

            output.WriteLine("Result:");
            output.WriteLine(result);

            return result;
        }

<<<<<<< Updated upstream
        [Fact]
        public byte[] SaveBinary()
        {
            var stream = CreateSerializer();

            var result = stream.Serialize(Person.Homer);
=======
        [Theory]
        [MemberData(nameof(PersonData))]
        public byte[] SaveBinary(Person person)
        {
            var stream = CreateSerializer();

            var result = stream.Serialize(person);
>>>>>>> Stashed changes

            output.WriteLine("Result:");
            output.WriteLine(System.Text.Encoding.Default.GetString(result));

            return result;
        }

<<<<<<< Updated upstream
        [Fact]
        public string SaveCustomType()
=======
        [Theory]
        [MemberData(nameof(EmployeeData))]
        public string SaveCustomType(Employee employee)
>>>>>>> Stashed changes
        {
            var stream = CreateSerializer(
                new [] { typeof(Person) },
                new [] { typeof(Person).Assembly });

<<<<<<< Updated upstream
            var result = stream.SerializeContent(Employee.Homer);
=======
            var result = stream.SerializeContent(employee);
>>>>>>> Stashed changes

            output.WriteLine("Result:");
            output.WriteLine(result);

            return result;
        }

<<<<<<< Updated upstream
        [Fact]
        public void Load()
        {
            var savedContent = Save();
=======
        [Theory]
        [MemberData(nameof(PersonData))]
        public void Load(Person person)
        {
            var savedContent = Save(person);
>>>>>>> Stashed changes

            output.WriteLine("Import:");
            output.WriteLine(savedContent.ToString());

            var stream = CreateSerializer();
<<<<<<< Updated upstream
            var person = stream.DeserializeContent<Person>(savedContent);

            output.WriteLine("\nResult:");
            output.WriteLine(person.ToString());

            Assert.Equal(person.Name, Person.Homer.Name);
        }

        [Fact]
        public void LoadBinary()
        {
            var savedBinary = SaveBinary();
=======
            var result = stream.DeserializeContent<Person>(savedContent);

            output.WriteLine("\nResult:");
            output.WriteLine(result.ToString());

            Assert.Equal(person.Name, result.Name);
        }

        [Theory]
        [MemberData(nameof(PersonData))]
        public void LoadBinary(Person person)
        {
            var savedBinary = SaveBinary(person);
>>>>>>> Stashed changes

            output.WriteLine("Import:");
            output.WriteLine(System.Text.Encoding.Default.GetString(savedBinary));

            var stream = CreateSerializer();
<<<<<<< Updated upstream
            var person = stream.Deserialize<Person>(savedBinary);

            output.WriteLine("\nResult:");
            output.WriteLine(person.ToString());

            Assert.Equal(person.Name, Person.Homer.Name);
=======
            var result = stream.Deserialize<Person>(savedBinary);

            output.WriteLine("\nResult:");
            output.WriteLine(result.ToString());

            Assert.Equal(person.Name, result.Name);
>>>>>>> Stashed changes
        }
    }
}
