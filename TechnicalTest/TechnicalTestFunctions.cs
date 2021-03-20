using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace TechnicalTest
{
    public static class TechnicalTestFunctions
    {
        private static Dictionary<decimal, decimal> CalculatedFib = new Dictionary<decimal, decimal>();
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

        /// <summary>
        /// Return the compressed string from a given string, if the compressed string length is greater than
        /// the original, the original string is returned
        /// </summary>
        /// <param name="strToCompress">string that will be compressed</param>
        /// <returns>(string) </returns>
        public static string GetCompressedStr(string strToCompress)
        {
            if (string.IsNullOrWhiteSpace(strToCompress)) return strToCompress;

            StringBuilder compressedStr = new StringBuilder();
            for (int i = 0; i < strToCompress.Length;)
            {
                int numRepetition = 0;
                char currentChar = strToCompress[i];
                do {
                    numRepetition++;
                    i++;
                } while (i < strToCompress.Length && currentChar == strToCompress[i]);

                compressedStr.Append(currentChar).Append(numRepetition);

                if (compressedStr.ToString().Length > strToCompress.Length) return strToCompress;
            }

            return compressedStr.ToString();
        }

        /// <summary>
        /// Calculate the Fibonacci secuence of a given number
        /// </summary>
        /// <param name="n">term number</param>
        /// <returns></returns>
        private static decimal Fibonacci(decimal n)
        {
            if (n == 0)
            {
                if (!CalculatedFib.ContainsKey(n))
                {
                    CalculatedFib.Add(n, 0);
                }
                return 0;
            }

            if (n == 1)
            {
                if (!CalculatedFib.ContainsKey(n))
                {
                    CalculatedFib.Add(n, 1);
                }
                return 1;
            }

            if (CalculatedFib.ContainsKey(n))
            {
                return CalculatedFib[n];
            }

            decimal newFibNumber = Fibonacci(n - 1) + Fibonacci(n - 2);
            CalculatedFib.Add(n, newFibNumber);
            return newFibNumber;
        }

        /// <summary>
        /// Return a list of the Fibonacci secuence using n as term number
        /// </summary>
        /// <param name="n">term number</param>
        /// <returns>qpwojdpoqjd´qpwojdqpowjd</returns>
        public static string CalculateFibSeries(decimal n)
        {
            Fibonacci(n);

            var fibSerie = CalculatedFib.Select(f => 
                string.Format("{0}\t:\t{1}", f.Key.ToString() ,f.Value.ToString()));

            return string.Join("\n", fibSerie);
        }
    }
}
