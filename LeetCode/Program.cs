using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LeetCode
{
    internal class Program
    {
        private static readonly Dictionary<(int, int), int> _cache = new();

        public static Dictionary<string, int> months = new() {
            { "Jan", 01 },
            { "Feb", 02 },
            { "Mar", 03 },
            { "Apr", 04 },
            { "May", 05 },
            { "Jun", 06 },
            { "Jul", 07 },
            { "Aug", 08 },
            { "Sep", 09 },
            { "Oct", 10 },
            { "Nov", 11 },
            { "Dec", 12 }
        };
        static void Main(string[] args)
        {
            Console.WriteLine(Min2(8, 2));
        }
        public static string LargestOddNumber(string num)
        {
            try
            {
                ReadOnlySpan<char> str = num;
                if (ulong.Parse(num[^1].ToString()) % 2 != 0) return num;
                for (int i = str.Length - 1; i >= 0; i--)
                {
                    var tempNum = ulong.Parse(str[i].ToString());
                    if (tempNum % 2 != 0) return num.Substring(0, num.Length - i);
                }
                return "";
            }
            catch (OverflowException)
            {
                return "";
            }
            catch (FormatException)
            {
                return "";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string ReformatDate(string date)
        {
            var dates = date.Split(' ');
            return $"{int.Parse(dates[2])}-{months[dates[1]]:00}-{int.Parse(Regex.Match(dates[0], @"\d+").Value):00}";
        }
        //I tried array deconstruction instead but this exercise is bad for performance.
        //The exercise is designed to be solved with 3 loops, even the hints says so.
        public static int UnequalTriplets(int[] nums)
        {
            int counter = 0;
            try
            {
                if (nums.Length < 3)
                {
                    return 0;
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        for (int k = j + 1; k < nums.Length; k++)
                        {
                            if (nums[i] != nums[j] && nums[i] != nums[k] && nums[j] != nums[k]) counter++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return counter;
        }
        public static int GetXORSum(int[] arr1, int[] arr2)
        {
            int a = 0;
            int b = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                a ^= arr1[i];
            }
            for (int i = 0; i < arr2.Length; i++)
            {
                b ^= arr2[i];
            }
            return (a & b);
        }
       
        public int MinimumOperationsToMakeEqual(int x, int y)
        {
            Dictionary<int, int> cache = [];
            int result = IterationsRecursive(x, y, cache);
            return result;
        }

        private int IterationsRecursive(int num, int y, Dictionary<int, int> cache)
        {
            if (cache.TryGetValue(num, out int val))
            {
                return val;
            }

            if (num <= y)
            {
                return y - num;
            }

            int result = Math.Abs(num - y);

            for (int i = 0; i < 11; i++)
            {
                if ((i + num) % 11 == 0)
                {
                    result = Math.Min(result, 1 + i + IterationsRecursive((i + num) / 11, y, cache));
                }

                if (num >= i && (num - i) % 11 == 0)
                {
                    result = Math.Min(result, 1 + i + IterationsRecursive((num - i) / 11, y, cache));
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if ((i + num) % 5 == 0)
                {
                    result = Math.Min(result, 1 + i + IterationsRecursive((num + i) / 5, y, cache));
                }

                if (num >= i && (num - i) % 5 == 0)
                {
                    result = Math.Min(result, 1 + i + IterationsRecursive((num - i) / 5, y, cache));
                }
            }

            cache[num] = result;
            return result;
        }
    }
}
