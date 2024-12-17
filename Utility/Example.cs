using DSA_Examples.Utility;

namespace DSA_Examples
{
    abstract class Example
    {
        public Test<object?>[] Tests { get; init; }

        public Example()
        {
            Tests = new Test<object?>[5];
        }
    }
}
