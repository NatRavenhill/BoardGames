using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGames.Models.Extensions
{
    /// <summary>
    /// Extension methods for strings
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Case insenstive version of Contains
        /// </summary>
        /// <param name="originalString">Original string to check</param>
        /// <param name="inputString">Input to check if original string contains</param>
        /// <returns></returns>
        public static bool ContainsIgnoringCase(this string originalString, string inputString)
        {
            return originalString.ToUpper().Contains(inputString.ToUpper());
        }
    }
}
