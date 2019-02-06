using System;

namespace SortOddNumbers
{
    internal class Program
    {
        private static void Main()
        {
            foreach (var i in SortArray(new[] {1, 5, 3, 2, 9, 7}))
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }
        public static int[] SortArray(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0 || array[i] == 0)
                    continue;

                for (var j = (i + 1); j < array.Length; j++)
                {
                    if (array[j] % 2 == 0 || array[i] == 0) continue;
                    if (array[i] <= array[j]) continue;
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            return array;
        }
    }
}
