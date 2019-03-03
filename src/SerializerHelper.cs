namespace Mallos.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public static class SerializerHelper
    {
        public static IEnumerable<Assembly> DependencyAssemblies()
        {
            return new Assembly[] {
                Assembly.GetEntryAssembly(),
                ThisAssembly(),
                typeof(string).Assembly
            };
        }

        public static IEnumerable<Type> DependencyTypes()
        {
            return new Type[] {
                // NOTE: Add types that we want.
            };
        }

        public static IEnumerable<Type> GetSerializableTypes(Assembly assembly = null)
        {
            return (assembly ?? ThisAssembly()).FindByAttribute<SerializableAttribute>();
        }

        private static Assembly ThisAssembly() => Assembly.GetAssembly(typeof(SerializerHelper));
    }
}
