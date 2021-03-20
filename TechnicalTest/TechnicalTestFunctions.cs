using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest
{
    public static class TechnicalTestFunctions
    {
        /// <summary>
        /// Returns the number of vowels it has
        /// </summary>
        /// <param name="strInput">string</param>
        /// <returns>(int) number of vowels</returns>
        public static int CountVowels(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) return 0;

            char[] vowals = { 'a', 'e', 'i', 'o', 'u' };

            int vowalsNum = strInput.ToLower().Count(c => vowals.Contains(c));

            return vowalsNum;
        }

    }
}
