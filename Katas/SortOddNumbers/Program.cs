using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Katas
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Output of SortAddNumbers: ");
            SortOddNumbers(new[] { 1, 5, 3, 2, 9, 7 }).ToList().ForEach(Console.WriteLine);

            Console.Write("Output of BreakCamelCase: ");
            Console.WriteLine(BreakCamelCase("ThisExampleBreaksCamelCaseSentences."));

            Console.Write("Output of SquareEveryDigit: ");
            Console.WriteLine(SquareEveryDigit(9119));

            Console.Write("Output of Factorial: ");
            Console.WriteLine(Factorial(3));

            Console.Write("High and Low: ");
            Console.WriteLine(HighAndLow("5 4 3 7 8 9 1 0 6"));

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
        public static int SquareEveryDigit(int number)
        {
            return int.Parse(number.ToString()
                .ToCharArray()
                .Select(char.GetNumericValue)
                .Select(a => Math.Pow(a, 2))
                .Aggregate("", (acc, s) => acc + s));
        }
        public static int Factorial(int number)
        {
            if (number < 0 || number > 12)
                throw new ArgumentOutOfRangeException(nameof(number), "The number must be between 0 and 12 (incl. 0 and 12)");
            return number > 0 ? number * Factorial(number - 1) : 1;
        }
        public static string HighAndLow(string numbers)
        {
            /* My Solution
            var numbersList = numbers.Split(' ').ToList();
            var min = int.Parse(numbersList.First());
            var max = int.Parse(numbersList.First());
            numbersList.ForEach(n =>
            {
                min = min > int.Parse(n) ? int.Parse(n) : min;
                max = max < int.Parse(n) ? int.Parse(n) : max;
            });
            return max + " " + min;*/

            // Best Practice
            var parsed = numbers.Split().Select(int.Parse).ToList();
            return parsed.Max() + " " + parsed.Min();
        }
    }
}
