using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalTest;

namespace TechnicalTest
{
    class Program
    {
       

        static void Main(string[] args)
        {
            string sentence = string.Empty;
            do
            {
                Console.WriteLine("\nEnter a Sentence or press q to exit");

                sentence = Console.ReadLine();
                string compressedString = TechnicalTestFunctions.GetCompressedStr(sentence);
                Console.WriteLine(compressedString);
            } while (sentence != "q");
        }
    }
}
