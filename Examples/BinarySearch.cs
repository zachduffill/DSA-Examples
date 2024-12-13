namespace DSA_Examples.Examples
{
    internal class BinarySearch : Example
    {
        static private int? Search(int[] arr, int q)
        {
            int lo = 0;
            int hi = arr.Length;
            int mp = arr.Length / 2;

            while (hi-lo > 0)
            {
                if (arr[mp] == q) return mp;

                if (q > arr[mp]) lo = mp + 1;
                else hi = mp;

                mp = lo + (hi - lo) / 2;
            }
            return -1;
        }

        public BinarySearch()
        {
            Tests = new Test<object?>[] {
                new Test<object?>("Normal",() => Search([0, 2, 3, 5, 8, 9, 30, 55, 58, 100], 3), 2),
                new Test<object?>("Negatives",() => Search([-495, -1, 0, 2, 5, 11, 14, 50, 98, 140], -495), 0),
                new Test<object?>("Nonexistent value",() => Search([1, 1, 2, 4, 500, 700, 900, 1100, 1101, 1102], 0), -1),
            };
        }
    }
}
