namespace Mallos.Serialization
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class SerializerStreamDataContractTest : Test
    {
        public SerializerStreamDataContractTest(ITestOutputHelper output)
            : base(output)
        {

        }

        protected abstract SerializerStream CreateSerializer();

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
        public void Load()
        {
            var import = Save();
            output.WriteLine("Import:");
            output.WriteLine(import.ToString());

            var stream = CreateSerializer();
            var person = stream.DeserializeContent<Person>(import);
            output.WriteLine("Result:");
            output.WriteLine(person.ToString());

            Assert.Equal(person.Name, Person.Homer.Name);
        }

        [Fact]
        public void LoadBinary()
        {
            var import = SaveBinary();
            output.WriteLine("Import:");
            output.WriteLine(import.ToString());

            var stream = CreateSerializer();
            var person = stream.Deserialize<Person>(import);
            output.WriteLine("Result:");
            output.WriteLine(person.ToString());

            Assert.Equal(person.Name, Person.Homer.Name);
        }
    }
}
