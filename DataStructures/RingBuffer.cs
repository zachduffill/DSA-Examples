using System.Drawing;

namespace DSA_Examples.Examples
{
    internal class RingBuffer : Example
    {
        private object?[] arr;
        private int rPt = 0; // read pointer
        private int wPt = 0; // write pointer

        public int Add(object? obj)
        {
            if (arr == null) return -1;

            int idx = wPt % arr.Length;
            if (idx == rPt && wPt > rPt) return -1;

            arr[idx] = obj;
            wPt++;

            return idx;
        }

        public object? Read()
        {
            int newrPt = (rPt + 1 == arr.Length) ? 0 : rPt + 1;
            if (newrPt == wPt % arr.Length) return -1;

            object? obj = arr[rPt];
            rPt = newrPt;

            return obj;
        }

        public override string ToString()
        {
            return string.Join(",",arr);
        }

        public RingBuffer()
        {
            arr = new object[3];

            Tests = new Test<object?>[]
            {
                new Test<object?>("Add",() => Add(1),0),
                new Test<object?>("Add",() => Add(2),1),
                new Test<object?>("Add",() => Add(3),2),
                new Test<object?>("Read",() => Read(),1),
                new Test<object?>("Add",() => Add(6),0),
                new Test<object?>("Add When Full",() => Add(1),-1),
                new Test<object?>("ToString",() => ToString(),"6,2,3"),
                new Test<object?>("Read",() => Read(),2),
                new Test<object?>("Read",() => Read(),3),
                new Test<object?>("Read on Write Pointer",() => Read(),-1),
            };
        }
    }
}
