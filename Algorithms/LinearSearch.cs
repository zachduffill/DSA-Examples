using DSA_Examples.Utility;

namespace DSA_Examples.Examples
{
    internal class LinearSearch : Example
    {
        static private int? Search(Object[] array, Object target) // Searches through a given arrayay for a target linearly, returning it's index if found       O(n)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(target)) return i;
            }
            return -1;
        }

        public LinearSearch()
        {
            Tests = new Test<object?>[] { 
                new Test<object?>("Ints",() => Search(new Object[] { 0, 8, 3, 5, 2 }, 8), 1), 
                new Test<object?>("Strings",() => Search(new Object[] { "cat", "dog", "tree", "door", "tap" }, "door"), 3),
                new Test<object?>("Bools",() => Search(new Object[] { true, true, false, false, true }, true), 0),
                new Test<object?>("Nonexistent value",() => Search(new Object[] { true, true, false, false, true }, 0), -1)
            };
        }
    }
}
