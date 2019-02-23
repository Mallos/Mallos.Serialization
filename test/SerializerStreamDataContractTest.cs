namespace Mallos.Serialization
{
    using System;
    using Xunit.Abstractions;

    public class SerializerStreamJsonTest : Test
    {        
        public SerializerStreamJsonTest(ITestOutputHelper output)
            : base(output)
        {

        }

        [Theory]
        [InlineData(new SerializerStreamJson())]
        [InlineData(new SerializerStreamXml())]
        public string Save(SerializerStream stream)
        {
            var result = stream.SerializeContent(Person.Homer);
            output.Write(result);

            return result;
        }

        [Theory]
        [InlineData(new SerializerStreamJson())]
        [InlineData(new SerializerStreamXml())]
        public byte[] SaveBinary(SerializerStream stream)
        {
            var result = stream.Serialize(Person.Homer);
            output.Write(result);

            return result;
        }

        [Theory]
        [InlineData(new SerializerStreamJson())]
        [InlineData(new SerializerStreamXml())]
        public void Load(SerializerStream stream)
        {
            var import = Save(stream);
            output.WriteLine("Import:");
            output.Write(import);

            var person = stream.DeserializeContent<Person>(import);
            output.WriteLine("Result:");
            output.Write(person);

            Assert.Equal(person, Person.Homer);
        }

        [Theory]
        [InlineData(new SerializerStreamJson())]
        [InlineData(new SerializerStreamXml())]
        public void LoadBinary(SerializerStream stream)
        {
            var import = SaveBinary(stream);
            output.WriteLine("Import:");
            output.Write(import);

            var person = stream.Deserialize<Person>(import);
            output.WriteLine("Result:");
            output.Write(person);

            Assert.Equal(person, Person.Homer);
        }
    }
}
