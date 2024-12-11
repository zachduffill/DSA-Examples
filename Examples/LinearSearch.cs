namespace DSA_Examples.Examples
{
    internal class LinearSearch : Example
    {
        private int? Search(Object[] arr, Object q)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == q) return i;
            }
            return null;
        }

        public override Test<object?>[] tests { get; init; }

        public LinearSearch()
        {
            tests = new Test<object?>[] { 
                new Test<object?>(() => Search(new Object[] { 0, 8, 3, 5, 2 }, 8), 1), 
                new Test<object?>(() => Search(new Object[] { "cat", "dog", "tree", "door", "tap" }, "door"), 3),
                new Test<object?>(() => Search(new Object[] { true, true, false, false, true }, true), 0)
            };
        }
    }
}
