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

        [Theory]
        [MemberData(nameof(PersonData))]
        public string Save(Person person)
        {
            var stream = CreateSerializer();

            var result = stream.SerializeContent(person);

            output.WriteLine("Result:");
            output.WriteLine(result);

            return result;
        }

        [Theory]
        [MemberData(nameof(PersonData))]
        public byte[] SaveBinary(Person person)
        {
            var stream = CreateSerializer();

            var result = stream.Serialize(person);

            output.WriteLine("Result:");
            output.WriteLine(System.Text.Encoding.Default.GetString(result));

            return result;
        }

        [Theory]
        [MemberData(nameof(EmployeeData))]
        public string SaveCustomType(Employee employee)
        {
            var stream = CreateSerializer(
                new [] { typeof(Person) },
                new [] { typeof(Person).Assembly });

            var result = stream.SerializeContent(employee);

            output.WriteLine("Result:");
            output.WriteLine(result);

            return result;
        }

        [Theory]
        [MemberData(nameof(PersonData))]
        public void Load(Person person)
        {
            var savedContent = Save(person);

            output.WriteLine("Import:");
            output.WriteLine(savedContent.ToString());

            var stream = CreateSerializer();
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

            output.WriteLine("Import:");
            output.WriteLine(System.Text.Encoding.Default.GetString(savedBinary));

            var stream = CreateSerializer();
            var result = stream.Deserialize<Person>(savedBinary);

            output.WriteLine("\nResult:");
            output.WriteLine(result.ToString());

            Assert.Equal(person.Name, result.Name);
        }
    }
}
