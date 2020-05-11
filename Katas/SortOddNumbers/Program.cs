using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Katas
{
    internal static class Program
    {
        private static void Main()
        {
            Console.Write("Output of SortAddNumbers: ");
            SortOddNumbers(new[] {1, 5, 3, 2, 9, 7}).ToList().ForEach(Console.WriteLine);

            Console.Write("Output of BreakCamelCase: ");
            Console.WriteLine(BreakCamelCase("ThisExampleBreaksCamelCaseSentences."));

            Console.Write("Output of SquareEveryDigit: ");
            Console.WriteLine(SquareEveryDigit(9119));

            Console.Write("Output of Factorial: ");
            Console.WriteLine(Factorial(3));

            Console.Write("High and Low: ");
            Console.WriteLine(HighAndLow("5 4 3 7 8 9 1 0 6"));

            Console.WriteLine("Human readable time: ");
            Console.WriteLine(GetHumanReadableTime(300));

            Console.WriteLine("Summation: ");
            Console.WriteLine(Summation(213));

            Console.WriteLine("array.diff");
            Console.WriteLine(string.Join(", ", ArrayDiff(new[] {1, 2, 2, 2, 3}, new[] {2})));

            Console.WriteLine("Create Phone Number");
            Console.WriteLine(CreatePhoneNumber(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 0}));

            Console.WriteLine("PaginationHelper");
            var helper = new PaginationHelper<char>(new List<char> {'a', 'b', 'c', 'd', 'e', 'f'}, 4);
            Console.WriteLine("Should be 2: " + helper.PageCount);
            Console.WriteLine("Should be 6: " + helper.ItemCount);
            Console.WriteLine("Should be 4: " + helper.PageItemCount(0));
            Console.WriteLine("Should be 2: " + helper.PageItemCount(1));
            Console.WriteLine("Should be -1: " + helper.PageItemCount(2));

            Console.WriteLine("Should be 1: " + helper.PageIndex(5));
            Console.WriteLine("Should be 0: " + helper.PageIndex(2));
            Console.WriteLine("Should be -1: " + helper.PageIndex(20));
            Console.WriteLine("Should be -1: " + helper.PageIndex(-10));

            var collection = new List<int>
                {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24};
            var helper1 = new PaginationHelper<int>(collection, 10);
            Console.WriteLine("Should be 3: " + helper1.PageCount);

            Console.WriteLine("Should be -1: " + helper1.PageItemCount(-1));
            Console.WriteLine("Should be 10: " + helper1.PageItemCount(1));
            Console.WriteLine("Should be 4: " + helper1.PageItemCount(2));
            Console.WriteLine("Should be -1: " + helper1.PageItemCount(3));

            Console.WriteLine("Should be -1: " + helper1.PageIndex(-1));
            Console.WriteLine("Should be 1: " + helper1.PageIndex(12));
            Console.WriteLine("Should be -1: " + helper1.PageIndex(24));
            Console.WriteLine("Should be 2: " + helper1.PageIndex(20));

            Console.WriteLine("ROT13");
            Console.WriteLine("EBG13 rknzcyr. should be ROT13 example.: " + Rot13("EBG13 rknzcyr."));
            Console.WriteLine("This is my first ROT13 excercise! should be Guvf vf zl svefg EBG13 rkprepvfr!: " +
                              Rot13("This is my first ROT13 excercise!"));
            Console.WriteLine(Rot13("Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf."));

            Console.WriteLine("Sum Strings as Numbers");
            Console.WriteLine("123, 456 should be 589: " + SumStrings("123", "456"));
            Console.WriteLine("123, 456 should be 589: " +
                              SumStrings("712569312664357328695151392", "8100824045303269669937").Length);

            Console.WriteLine("Josephus Permutation");
            Console.WriteLine("[1, 2, 3, 4, 5, 6, 7, 8, 9, 10], 2 shoul be [2, 4, 6, 8, 10, 3, 7, 1, 9, 5]: " +
                              string.Join(", ",
                                  JosephusPermutation(new List<object> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}, 2)));

            Console.WriteLine("Stop gninnipS My sdroW! => " + SpinWords("Stop gninnipS My sdroW") + "!");
            Console.WriteLine("Jaden Casing Strings => " +
                              "How can mirrors be real if our eyes aren't real".ToJadenCase());
            Console.WriteLine("Credit Card Mask 4556364607935616 => " + Maskify("4556364607935616"));

            Console.WriteLine("0 should be 1 second: " + FormatDuration(3600 * 24 * 365 * 2 + (3600 * 2) + 185));



            Console.WriteLine("Sudoku validation: " + ValidateSodoku(new int[][]
            {
                new[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
                new[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
                new[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
                new[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
                new[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
                new[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
                new[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
                new[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
                new[] {3, 4, 5, 2, 8, 6, 1, 7, 9}
            }));

        Console.ReadLine();
        }

        public static object Int16 { get; set; }

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
        public static int SquareEveryDigit(int number) => int.Parse(number.ToString()
            .ToCharArray()
            .Select(char.GetNumericValue)
            .Select(a => Math.Pow(a, 2))
            .Aggregate("", (acc, s) => acc + s));
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
        private static string GetHumanReadableTime(int seconds)
        {
            /*My solution
            var hours = seconds / 3600;
            var minutes = (seconds - hours * 3600) / 60;
            var totalUsedSeconds = minutes * 60 + hours * 3600;
            seconds -= totalUsedSeconds;

            var mm = minutes < 10 ? "0" + minutes : minutes.ToString();
            var hh = hours < 10 ? "0" + hours : hours.ToString();
            var ss = seconds < 10 ? "0" + seconds : seconds.ToString();
            return $"{hh}:{mm}:{ss}";*/
            //best solution
            return $"{seconds / 3600:d2}:{seconds / 60 % 60:d2}:{seconds % 60:d2}";
        }
        private static int Summation(int num)
        {
            var summationTotal = 0;
            for (var number = 1; number <= num; number++)
                summationTotal += number;
            return summationTotal;
        }
        private static IEnumerable<int> ArrayDiff(IEnumerable<int> a, int[] b) => a.Where(x => !b.Contains(x)).ToArray();
        private static string CreatePhoneNumber(int[] numbers) =>
            $"({string.Join(string.Empty, new ArraySegment<int>(numbers, 0, 3))}) {string.Join(string.Empty, new ArraySegment<int>(numbers, 3, 3))}-{string.Join(string.Empty, new ArraySegment<int>(numbers, 6, 4))}";
        private static string Rot13(string input)
        {
            const char a = 'a';
            const char z = 'z';
            const char capitalA = 'A';
            const char capitalZ = 'Z';

            var result = new StringBuilder(string.Empty);
            foreach (var c in input)
            {
                var newChar = c + 13;
                if (a <= c && c <= z)
                {
                    if (newChar > z)
                    {
                        newChar -= z;
                        newChar += a-1;
                    }
                }
                else if(c >= capitalA && c <= capitalZ)
                {
                    if (newChar > capitalZ)
                    {
                        newChar -= capitalZ;
                        newChar += capitalA-1;
                    }
                }
                else
                    newChar = c;
                result.Append(Convert.ToChar(newChar).ToString());
            }
            return result.ToString();
        }
        private static string SumStrings(string a, string b)
        {
            BigInteger.TryParse(a, out var aInt);
            BigInteger.TryParse(b, out var bInt);
            return (aInt + bInt).ToString();
        }
        private static IEnumerable<object> JosephusPermutation(IList<object> items, int k)
        {
            var order = new object[items.Count];
            var a = 0;
            var b = 0;
            var c = 0;
            var n = items.Count;

            while (items.Count != 0)
            {
                b++;
                if (b == k)
                {
                    order[c] = items[a];
                    items.RemoveAt(a);

                    c++;
                    a--;
                    b = 0;
                }
                if (c == n - 1)
                {
                    order[c] = items[0];
                    items.RemoveAt(0);
                }
                if (a == items.Count - 1)
                    a = 0;
                else
                    a++;
            }
            return order.ToList();
        }
        private static string SpinWords(string sentence) => string.Join(" ",
            sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
        private static string ToJadenCase(this string phrase) =>
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        private static string Maskify(string cc)
        {
            if (cc.Length <= 4) return cc;
            var result = new StringBuilder(string.Empty);
            
            for (var i = 0; i < cc.Length - 4; i++) result.Append("#");
            return result + cc.Substring(cc.Length - 4);
        }
        private static string FormatDuration(int seconds)
        {
            const int daysInYear = 365;
            const int dayHours = 24;
            const int minutesInHour = 60;
            const int secondsInMinute = 60;
            var result = string.Empty;
            var remainingSeconds = seconds;
            var years = 0;
            var hours = 0;
            var minutes = 0;
            var yearString = string.Empty;
            var daysString = string.Empty;
            var hoursString = string.Empty;
            var minutesString = string.Empty;
            var secondsString = string.Empty;
            var days = 0;
            
            if (remainingSeconds == 0)
                return "now";

            if (remainingSeconds >= daysInYear * dayHours * minutesInHour * secondsInMinute)
            {
                years = remainingSeconds / (daysInYear * dayHours * minutesInHour * secondsInMinute);
                if (years == 1)
                    yearString = years + " year";
                else
                    yearString = years + " years";
            }
            remainingSeconds = seconds - years * daysInYear * dayHours * minutesInHour * secondsInMinute;

            if (remainingSeconds >= dayHours * minutesInHour * secondsInMinute)
            {
                days = remainingSeconds / (dayHours * minutesInHour * secondsInMinute);
                if (days == 1)
                    daysString = days + " day";
                else 
                    daysString = days + " days";
            }
            remainingSeconds = remainingSeconds - days * dayHours * minutesInHour * secondsInMinute;

            if (remainingSeconds >= minutesInHour * secondsInMinute)
            {
                hours = remainingSeconds / (minutesInHour * secondsInMinute);
                if (hours == 1)
                    hoursString = hours + " hour";
                else
                    hoursString = hours + " hours";
            }
            remainingSeconds = remainingSeconds - hours * minutesInHour * secondsInMinute;

            if (remainingSeconds >= secondsInMinute)
            {
                minutes = remainingSeconds / secondsInMinute;
                if (minutes == 1)
                    minutesString = minutes + " minute";
                else
                    minutesString = minutes + " minutes";
            }
            remainingSeconds = remainingSeconds - minutes * secondsInMinute;

            if (remainingSeconds == 1)
                secondsString = remainingSeconds + " second";
            else if (remainingSeconds > 1) 
                secondsString = remainingSeconds + " seconds";
            
            if (!string.IsNullOrEmpty(yearString))
                result += yearString;

            if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(daysString))
                result += daysString;
            else if (!string.IsNullOrEmpty(daysString) && (!string.IsNullOrEmpty(hoursString) || !string.IsNullOrEmpty(minutesString) || !string.IsNullOrEmpty(secondsString)))
                result += ", " + daysString;
            else if (!string.IsNullOrEmpty(daysString) && string.IsNullOrEmpty(hoursString) && string.IsNullOrEmpty(minutesString) && string.IsNullOrEmpty(secondsString))
                result += " and " + daysString;

            if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(hoursString))
                result += hoursString;
            else if (!string.IsNullOrEmpty(hoursString) && (!string.IsNullOrEmpty(minutesString) || !string.IsNullOrEmpty(secondsString)))
                result += ", " + hoursString;
            else if (!string.IsNullOrEmpty(hoursString) && string.IsNullOrEmpty(minutesString) && string.IsNullOrEmpty(secondsString))
                result += " and " + hoursString;

            if (!string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(minutesString) && !string.IsNullOrEmpty(secondsString))
                result += ", " + minutesString + " and " + secondsString;
            else if (!string.IsNullOrEmpty(result) && string.IsNullOrEmpty(minutesString) && !string.IsNullOrEmpty(secondsString))
                result += " and " + secondsString;
            else if (string.IsNullOrEmpty(result) && string.IsNullOrEmpty(minutesString) && !string.IsNullOrEmpty(secondsString))
                result += secondsString;
            else if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(minutesString) && !string.IsNullOrEmpty(secondsString))
                result += minutesString + " and " + secondsString;
            else if (!string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(minutesString) && string.IsNullOrEmpty(secondsString))
                result += " and " + minutesString;
            else if (string.IsNullOrEmpty(result) && !string.IsNullOrEmpty(minutesString) && string.IsNullOrEmpty(secondsString))
                result += minutesString;
            return result;
        }

        private static int[][] _grid;
        private static bool ValidateSodoku(int[][] grid)
        {
            _grid = grid;
            return RowsAreValid()
                   && ColumnsAreValid()
                   && SquaresAreValid();
        }
        private static bool RowsAreValid() => Validate(GetNumberFromRow);
        private static bool ColumnsAreValid() => Validate(GetNumberFromColumn);
        private static bool SquaresAreValid() => Validate(GetNumberFromSquare);
        private static bool Validate(Func<int, int, int> numberGetter)
        {
            for (var row = 0; row < 9; row++)
            {
                var usedNumbers = new bool[10];
                for (var column = 0; column < 9; column++)
                {
                    var number = numberGetter(row, column);
                    if (number == 0 || usedNumbers[number]) return false;
                    usedNumbers[number] = true;
                }
            }
            return true;
        }
        private static int GetNumberFromRow(int row, int column) => _grid[row][column];
        private static int GetNumberFromColumn(int row, int column) => _grid[column][row];
        private static int GetNumberFromSquare(int block, int index)
        {
            const int length = 3;
            var column = length * (block % length) + index % length;
            var row = index / length + length * (block / length);
            return _grid[row][column];
        }
    }
}
