using System.Drawing;

namespace DSA_Examples.Examples
{
    internal class RingBuffer : Example
    {
        private object?[] array;
        private int readPointer = 0; 
        private int writePointer = 0;

        public int Add(object? obj) // Adds an object at the writePointer, and increments it        O(1)
        {
            if (array == null) return -1;

            int idx = writePointer % array.Length;
            if (idx == readPointer && writePointer > readPointer) return -1;

            array[idx] = obj;
            writePointer++;

            return idx;
        }

        public object? Read() // Returns the object at the readPointer, and increments it        O(1)
        {
            int newreadPointer = (readPointer + 1 == array.Length) ? 0 : readPointer + 1;
            if (newreadPointer == writePointer % array.Length) return -1;

            object? obj = array[readPointer];
            readPointer = newreadPointer;

            return obj;
        }

        public override string ToString()
        {
            return string.Join(",",array);
        }

        public RingBuffer()
        {
            array = new object[3];

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
