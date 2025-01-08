
namespace DSA_Examples.Examples
{
    internal class QuickSort : Example
    {
        static private int[] Sort(int[] arr)
        {
            qs(ref arr, 0, arr.Length - 1);
            return arr;
        }

        static private void qs(ref int[] arr, int lo, int hi)
        {
            if (lo >= hi) return;

            int p = Partition(ref arr, lo, hi);

            qs(ref arr, lo, p-1);
            qs(ref arr, p + 1, hi);
        }

        static private int Partition(ref int[] arr, int lo, int hi)
        {
            int p = lo + (hi - lo) / 2;

            Swap(ref arr, hi, p);
            p = lo;

            for (int i = lo; i < hi; i++)
            {
                if (arr[i] <= arr[hi])
                {
                    Swap(ref arr, p, i);
                    p++;
                }
            }

            Swap(ref arr, p, hi);
            return p;
        }

        static private void Swap(ref int[] arr, int idx1, int idx2)
        {
            int tmp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = tmp;
        }

        public QuickSort()
        {
            Tests = new Test<object?>[]
            {
                new Test<object?>("Normal",() => Sort([0,6,3,2,8,9,4,6,1,5]),new int[10] { 0,1,2,3,4,5,6,6,8,9 }),
                new Test<object?>("Negative",() => Sort([-5,50,2,-105,7,0,2,4,1,50]),new int[10] { -105,-5,0,1,2,2,4,7,50,50 }),
                new Test<object?>("Pre-sorted",() => Sort([1,2,3,4,5,6,7,8,9,10]),new int[10] { 1,2,3,4,5,6,7,8,9,10 }),
                new Test<object?>("Reverse Pre-sorted",() => Sort([10,9,8,7,6,5,4,3,2,1]),new int[10] { 1,2,3,4,5,6,7,8,9,10 }),
            };
        }
    }
}
