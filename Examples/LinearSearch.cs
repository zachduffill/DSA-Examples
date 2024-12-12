namespace DSA_Examples.Examples
{
    internal class LinearSearch : Example
    {
        static private int? Search(Object[] arr, Object q)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Equals(q)) return i;
            }
            return -1;
        }

        public LinearSearch()
        {
            Tests = new Test<object?>[] { 
                new Test<object?>(() => Search(new Object[] { 0, 8, 3, 5, 2 }, 8), 1), 
                new Test<object?>(() => Search(new Object[] { "cat", "dog", "tree", "door", "tap" }, "door"), 3),
                new Test<object?>(() => Search(new Object[] { true, true, false, false, true }, true), 0),
                new Test<object?>(() => Search(new Object[] { true, true, false, false, true }, 0), -1)
            };
        }
    }
}
