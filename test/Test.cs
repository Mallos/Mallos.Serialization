namespace Mallos.Serialization
{
    using Xunit.Abstractions;

    public abstract class Test
    {
        protected readonly ITestOutputHelper output;

        public Test(ITestOutputHelper output)
        {
            this.output = output;
        }
    }
}
