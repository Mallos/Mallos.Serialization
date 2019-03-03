namespace Mallos.Serialization.DataContract
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Abstractions;

    public class SerializerStreamJsonTest : SerializerStreamDataContractTest
    {
        public SerializerStreamJsonTest(ITestOutputHelper output)
            : base(output)
        {
            
        }

        protected override SerializerStream CreateSerializer(
            IEnumerable<Type> types = null, IEnumerable<Assembly> assemblies = null)
        {
            return new SerializerStreamJson(types);
        }
    }
}
