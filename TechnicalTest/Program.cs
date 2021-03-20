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
            string[] words = new string[] { "CarS", "REPAID", "DUES", "NOSE", "SIgneD", "LANE", "PAIRED", "ARCS", "GRAB", "USED", "ONES", "BraG", "SUED", "LEan", "SCAR", "DESIGN" };
            //string[] words = new string[] { "cat", "dog", "tac", "god" };
            Console.WriteLine(TechnicalTestFunctions.GetSortedAnagram(words));
            Console.ReadLine();
        }
    }
}
