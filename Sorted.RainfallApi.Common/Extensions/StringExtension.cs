using System.Text.RegularExpressions;

namespace Sorted.RainfallApi.Extensions
{
    /// <summary>
    /// Provides extension methods for string
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Validates if a string is a number
        /// </summary>
        /// <param name="str">String</param>
        /// <returns></returns>
        public static bool IsNumber(this string str)
        {
            Regex regex = new Regex(@"^\d+$");
            return regex.IsMatch(str);
        }
    }
}
