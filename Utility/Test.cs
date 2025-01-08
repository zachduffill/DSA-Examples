using System.Collections;

namespace DSA_Examples
{
    internal class Test<T>
    {
        string Name { get; init; } 
        Func<T> Method { get; init; } // The method to be tested
        object? Expected { get; init; } // Expected output value from the method
        public Test(string name, Func<T> method, object? expected)
        {
            Name = name;
            Method = method;
            Expected = expected;
        }
        public bool Run() // Call the method and return True if it returns the Expected value
        {
            object? result = Method();
            if (result == null) return false;

            (string expStr, string resStr, bool equal) = HandleAndCompare(Expected, result);
            Console.WriteLine($" Expected   {expStr}");
            Console.WriteLine($" Actual     {resStr}");

            if (equal || Expected == null) return true;
            else return false;
        }
        private static (string, string, bool) HandleAndCompare(object? exp, object res) // Handles object types (due to differences in value comparison and string conversion)
        {
            string expStr, resStr;
            bool equal = false;

            if (exp is Array expArr && res is Array resArr)
            {
                expStr = $"[{string.Join(", ", expArr.Cast<object>().Select(x => x?.ToString() ?? "N/A"))}]";
                resStr = $"[{string.Join(", ", resArr.Cast<object>().Select(x => x?.ToString() ?? "null"))}]";
                if (StructuralComparisons.StructuralEqualityComparer.Equals(exp, res)) equal = true;
            }
            else
            {
                expStr = exp?.ToString() ?? "N/A";
                resStr = res.ToString() ?? "";
                if (res.Equals(exp)) equal = true;
            }

            return (expStr, resStr, equal);
        }

        public static void RunTests(Test<object?>[] tests) // Runs each Test in an array of Tests, and prettifies the results for the console.
        {
            Console.Clear();
            Console.WriteLine("\x1b[3J"); // Removes contents of whole console (without this, only content within the viewport will be cleared)
            for (int i = 0; i < tests.Length; i++)
            {
                Console.WriteLine($"-- Test {i + 1}: {tests[i].Name} --");
                string dashes = new string('-', tests[i].Name.Length + 1);

                try
                {
                    bool testSucceeded = tests[i].Run();
                    Console.ForegroundColor = testSucceeded ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine(testSucceeded ? $"-- Success --{dashes}" : $"-- Failure --{dashes}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{e.StackTrace}\n{e.Message}\n-- Failure --{dashes}");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
        }
    }
}
