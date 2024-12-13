using System.Collections;

namespace DSA_Examples
{
    internal class Test<T>
    {
        string Name { get; init; }
        Func<T> Method { get; init; }
        object Expected { get; init; }
        public Test(string name, Func<T> method, object expected)
        {
            Name = name;
            Method = method;
            Expected = expected;
        }
        public bool Run()
        {
            object? result = Method();
            if (result == null) return false;

            (string expStr, string resStr, bool equal) = HandleAndCompare(Expected, result);
            Console.WriteLine($" Expected   {expStr}");
            Console.WriteLine($" Actual     {resStr}");

            if (equal) return true;
            else return false;
        }
        private static (string,string,bool) HandleAndCompare(object exp, object res) // Handles object types (due to differences in value comparison and string conversion)
        {
            string expStr, resStr;
            bool equal = false;

            if (exp is Array expArr && res is Array resArr)
            {
                expStr = $"[{string.Join(", ", expArr.Cast<object>().Select(x => x?.ToString() ?? "null"))}]";
                resStr = $"[{string.Join(", ", resArr.Cast<object>().Select(x => x?.ToString() ?? "null"))}]";
                if (StructuralComparisons.StructuralEqualityComparer.Equals(exp, res)) equal = true;
            }
            else
            {
                expStr = exp.ToString() ?? "";
                resStr = res.ToString() ?? "";
                if (res.Equals(exp)) equal = true;
            }

            return (expStr, resStr, equal);
        }

        public static void RunTests(Test<object?>[] tests)
        {
            Console.Clear();
            for (int i = 0; i < tests.Length; i++)
            {
                Console.WriteLine($"-- Test {i + 1}: {tests[i].Name} --");
                string dashes = new string('-', tests[i].Name.Length + 1);

                try
                {
                    if (tests[i].Run()) Console.WriteLine($"-- Success --{dashes}");
                    else Console.WriteLine($"-- Failure --{dashes}");
                }
                catch(Exception e)
                {
                    Console.WriteLine($"{e.StackTrace}\n{e.Message}\n-- Failure --{dashes}");
                }

                Console.WriteLine();
            }
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
        }
    }
}
