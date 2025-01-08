using DSA_Examples.Utility;

namespace DSA_Examples.Examples
{
    internal class TwoCrystalBalls : Example
    {
        static private int Search(bool[] floors)
        {
            int jumpSize = (int)Math.Floor(Math.Sqrt(floors.Length));

            int i = jumpSize;  
            for (i = 0; i < floors.Length; i += jumpSize)
            {
                if (floors[i] == true) break;
            }

            for (int j = Math.Max(i - jumpSize,0); j <= i && j < floors.Length; j++)
            {
                if (floors[j] == true) return j;
            }

            return -1;
        }

        public TwoCrystalBalls()
        {
            Tests = new Test<object?>[] {
                new Test<object?>("Normal",() => Search([false,false,false,false,true,true,true,true,true,true]),4),
                new Test<object?>("End",() => Search([false,false,false,false,false,false,false,false,false,true]),9),
                new Test<object?>("All True",() => Search([true,true,true,true,true,true,true,true,true,]),0),
                new Test<object?>("No Trues",() => Search([false,false,false,false,false,false,false,false,false,false]),-1),
            };
        }
    }
}
