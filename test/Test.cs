namespace Mallos.Serialization
{
    using System.Collections.Generic;
    using Xunit.Abstractions;

    public abstract class Test
    {
        protected readonly ITestOutputHelper output;

        public Test(ITestOutputHelper output)
        {
            this.output = output;
        }

        public static IEnumerable<object[]> PersonData =>
            new List<object[]>
            {
                new [] { new Person("Homer Simpson", age: 39) },
                new [] { new Person("Marge Simpson", age: 36) },
                new [] { new Person("Bart Simpson", age: 10) },
                new [] { new Person("Lisa Simpson", age: 8) },
                new [] { new Person("Maggie Simpson", age: 1) }
            };

        public static IEnumerable<object[]> EmployeeData => 
            new List<object[]>
            {
                new [] { new Employee(new Person("Homer Simpson", age: 39), "Nuclear Safety Inspector") }
            };
    }
}
