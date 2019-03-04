namespace Mallos.Serialization.Reflection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> FindDerivedTypes<T>(this Assembly assembly)
            => assembly.FindDerivedTypes(typeof(T));

        public static IEnumerable<Type> FindDerivedTypes(this Assembly assembly, Type baseType)
            => assembly.GetTypes().Where((type) => type != baseType && baseType.IsAssignableFrom(type));

        public static IEnumerable<Type> FindByAttribute<T>(this Assembly assembly)
            => assembly.FindByAttribute(typeof(T));

        public static IEnumerable<Type> FindByAttribute(this Assembly assembly, Type findType)
            => assembly.GetTypes().Where((type) => type.GetCustomAttributes(findType, true).Length > 0);
    }
}
