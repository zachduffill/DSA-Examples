namespace DSA_Examples.Examples
{
    internal class BubbleSort : Example
    {
        static private int[] Sort(int[] arr)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int tmp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = tmp;
                    }
                }
            }

            return arr;
        }

        public BubbleSort()
        {
            Tests = new Test<object?>[] {
                new Test<object?>("Normal",() => Sort([0, 8, 3, 5, 2]), new int[5] { 0, 2, 3, 5, 8 }),
                new Test<object?>("Negatives",() => Sort([5, 2, 11, 0, -1]), new int[5] { -1, 0, 2, 5, 11 }),
                new Test<object?>("Reversed",() => Sort([500, 4, 2, 1, 1]), new int[5] { 1, 1, 2, 4, 500 }),
            };
        }
    }
}
