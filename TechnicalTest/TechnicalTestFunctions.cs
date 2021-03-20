using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        /// <summary>
        /// Return true if strInput is palindrome false if it is not
        /// </summary>
        /// <param name="strInput">string</param>
        /// <returns>(bool) is strInput a palindrome or not</returns>
        public static bool IsPalindrome(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput) || strInput.Length < 2) return false;

            string strInputNoBlanks = Regex.Replace(strInput, @"\s+|[^a-zA-Z0-9]", "").ToLower();
            int i = 0, j = strInputNoBlanks.Length - 1;
            while (i < j)
            {
                if (strInputNoBlanks[i] != strInputNoBlanks[j]) return false;

                if (i >= j) return true;

                i++; j--;
            }

            return true;
        }
    }
}
