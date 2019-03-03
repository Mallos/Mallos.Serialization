namespace Mallos.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit.Abstractions;

    public class SerializerStreamXmlTest : SerializerStreamDataContractTest
    {
        public SerializerStreamXmlTest(ITestOutputHelper output)
            : base(output)
        {

        }

        protected override SerializerStream CreateSerializer(
            IEnumerable<Type> types = null, IEnumerable<Assembly> assemblies = null)
        {
            return new SerializerStreamXml(assemblies, types);
        }
    }
}
