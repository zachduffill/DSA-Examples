namespace DSA_Examples
{
    internal class Test<T>
    {
        Func<T> Method { get; init; }
        T Expected { get; init; }
        public Test(Func<T> method, T expected)
        {
            Method = method;
            Expected = expected;
        }
        public bool Run()
        {
            T result = Method();
            if (result == null) return false;

            Console.WriteLine($"Expected   {Expected}");
            Console.WriteLine($"Actual     {result}");

            if (result.Equals(Expected)) return true;
            return false;
        }
    }
}
