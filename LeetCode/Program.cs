using System.Text.RegularExpressions;

namespace LeetCode
{
    internal class Program
    {
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
            Console.WriteLine(ReformatDate("6th Jun 1933"));
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
    }

}
