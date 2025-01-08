using DSA_Examples.Utility;

namespace DSA_Examples.Examples
{
    internal class BubbleSort : Example
    {
        static private int[] Sort(int[] arr) // Sorts a given int array, and returns it     O(n^2)
        {
            for (int j = 1; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length - j; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr, i, i + 1);
                    }
                }
            }

            return arr;
        }

        static private void Swap(ref int[] arr, int idx1, int idx2) // Given two indices, swaps their values in an array
        {
            int tmp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = tmp;
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
