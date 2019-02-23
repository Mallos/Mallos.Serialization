namespace Mallos.Serialization
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class SerializerStreamJsonTest : SerializerStreamDataContractTest
    {
        public SerializerStreamJsonTest(ITestOutputHelper output)
            : base(output)
        {
            
        }

        protected override SerializerStream CreateSerializer()
        {
            return new SerializerStreamJson();
        }
    }
}
