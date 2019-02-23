namespace Mallos.Serialization
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class SerializerStreamXmlTest : SerializerStreamDataContractTest
    {
        public SerializerStreamXmlTest(ITestOutputHelper output)
            : base(output)
        {

        }

        protected override SerializerStream CreateSerializer()
        {
            return new SerializerStreamXml();
        }
    }
}
