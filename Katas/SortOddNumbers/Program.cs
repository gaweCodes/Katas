using System;
using System.Text.RegularExpressions;

namespace Katas
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Output of SortAddNumbers: ");
            foreach (var i in SortOddNumbers(new[] {1, 5, 3, 2, 9, 7}))
                Console.WriteLine(i);
            Console.WriteLine(BreakCamelCase("ThisExampleBreaksCamelCaseSentences."));
            Console.ReadLine();
        }
        public static string BreakCamelCase(string str)
        {
            return Regex.Replace(str, "([A-Z])", " $1").Trim();
        }
        public static int[] SortOddNumbers(int[] numbers)
        {
            for (var index = 0; index < numbers.Length; index++)
            {
                if (numbers[index] % 2 == 0 || numbers[index] == 0) continue;
                for (var j = index + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] % 2 == 0 || numbers[index] == 0) continue;
                    if (numbers[index] <= numbers[j]) continue;
                    var swapNumber = numbers[index];
                    numbers[index] = numbers[j];
                    numbers[j] = swapNumber;
                }
            }
            return numbers;
        }
    }
}
