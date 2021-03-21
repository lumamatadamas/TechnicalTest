using System;
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
        public static string CountVowels(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) return string.Format("{0} has {1} vowels", strInput, 0);

            char[] vowals = { 'a', 'e', 'i', 'o', 'u' };

            int vowalsNum = strInput.ToLower().Count(c => vowals.Contains(c));

            return string.Format("{0} has {1} vowels\n", strInput, vowalsNum);
        }

        /// <summary>
        /// Returns a string saying if a given string is palindrome or not
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
        /// Returns the compressed string from a given string, if the compressed string length is greater than
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
        /// Returns a list of the Fibonacci secuence using n as term number
        /// </summary>
        /// <param name="n">term number</param>
        /// <returns></returns>
        public static string CalculateFibSeries()
        {
            //Calculate fibonacci series of 100
            Fibonacci(100);

            var fibSerie = CalculatedFib.Select(f => 
                string.Format("{0}\t:\t{1}", f.Key.ToString() ,f.Value.ToString()));

            return string.Join("\n", fibSerie);
        }

        /// <summary>
        /// Returns a sorted ascending string of anagrams from a string array given
        /// </summary>
        /// <param name="words">array of strings</param>
        /// <returns></returns>
        public static string GetSortedAnagrams(string[] words)
        {
            if (words.Length == 0 || words == null)
                return string.Empty;

            var anagrams = new Dictionary<int, List<Tuple<int, string>>>();

            //a Tuple<int,string> array is generated and it has as item1 the position of the word in the original arrays (words parameter) and as item2 the lowecase value of that current word
            var lowerWords = words.Select((word, index) => new Tuple<int, string>(index, word.ToLower())).ToArray();

            //sort the tuple array by words in ascending order
            var sortedWords = lowerWords.OrderBy(w => w.Item2);

            for (int i = 0; i < sortedWords.Count(); i++)
            {
                // generate the code shared between anagrams words
                int code = Encoding.ASCII.GetBytes(sortedWords.ElementAt(i).Item2).Aggregate(0, (prev, cur) => prev + cur);

                //if the code does not already exist as key value in the anagrams variable, this code and his related anagram represented by a tuple that contains the index in the original array as value of item1 and the anagram as value of item2 is added, in case that the code already exist only the anagram and his index in the original array is added to the tuple list related with that code
                if (!anagrams.ContainsKey(code))
                {
                    anagrams.Add(code, new List<Tuple<int, string>>() { sortedWords.ElementAt(i) });
                }
                else
                {
                    anagrams[code].Add(sortedWords.ElementAt(i));
                }
            }

            string sortedAnagram = string.Empty;

            //retrieve the index of each anagram from anagrams variable as an Array of integers
            var sortedIndexes = anagrams.SelectMany(c => c.Value).Select(c => c.Item1).ToArray();

            //concatenate the anagrams from the original array taking the order from the sortedIndexes array
            foreach (int index in sortedIndexes)
            {
                sortedAnagram = string.Concat(sortedAnagram, ",", words[index]);
            }

            return sortedAnagram.Trim(',');
        }
    }
}
