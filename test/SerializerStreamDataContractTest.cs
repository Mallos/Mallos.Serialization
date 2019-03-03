namespace Mallos.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class SerializerStreamDataContractTest : Test
    {
        private readonly string savedContent;
        private readonly byte[] savedBinary;

        public SerializerStreamDataContractTest(ITestOutputHelper output)
            : base(output)
        {
            this.savedContent = Save();
            this.savedBinary = SaveBinary();
        }

        protected abstract SerializerStream CreateSerializer(
            IEnumerable<Type> types = null, IEnumerable<Assembly> assemblies = null
        );

        [Fact]
        public string Save()
        {
            var stream = CreateSerializer();

            var result = stream.SerializeContent(Person.Homer);
            output.WriteLine(result);

            return result;
        }

        [Fact]
        public byte[] SaveBinary()
        {
            var stream = CreateSerializer();

            var result = stream.Serialize(Person.Homer);
            output.WriteLine(result.ToString());

            return result;
        }

        [Fact]
        public string SaveCustomType()
        {
            var stream = CreateSerializer(
                new [] { typeof(Person) },
                new [] { typeof(Person).Assembly });

            var result = stream.SerializeContent(Employee.Homer);
            output.WriteLine(result);

            return result;
        }

        [Fact]
        public void Load()
        {
            output.WriteLine("Import:");
            output.WriteLine(savedContent.ToString());

            var stream = CreateSerializer();
            var person = stream.DeserializeContent<Person>(savedContent);
            output.WriteLine("Result:");
            output.WriteLine(person.ToString());

            Assert.Equal(person.Name, Person.Homer.Name);
        }

        [Fact]
        public void LoadBinary()
        {
            output.WriteLine("Import:");
            output.WriteLine(savedBinary.ToString());

            var stream = CreateSerializer();
            var person = stream.Deserialize<Person>(savedBinary);
            output.WriteLine("Result:");
            output.WriteLine(person.ToString());

            Assert.Equal(person.Name, Person.Homer.Name);
        }
    }
}
