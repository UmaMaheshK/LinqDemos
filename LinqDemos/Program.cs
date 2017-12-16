using System;
using System.Linq;

namespace LinqDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            //DistinctText();
            //Rewrite_ForEach_Loop();
            //SumTwoDimentionalArray();
            TwoStringArraysWithDistinct();
        }

        //Find Distinct Text
        static void DistinctText()
        {
            string text = "angular,.net,SQL,angular";
            text.Split(',').Distinct().ToList().ForEach(p => Console.WriteLine(p));
            //text.Split(',').Distinct().ToList().ForEach(Console.WriteLine);
            //Console.WriteLine(result);
        }
        //Rewrite foreach loop using linq
        static void Rewrite_ForEach_Loop()
        {
            var uCase = new[] { "A", "B", "C", "D" };
            var lCase = new[] { "a", "b", "c", "d" };
            uCase.SelectMany(uc => lCase, (uc, lc) => (uc + lc)).ToList().ForEach(Console.WriteLine);
        }
        //Sum of MultDimentional array.
        static void SumTwoDimentionalArray()
        {
            var arry = new[,]
            {
                {1,2 },
                {3,4 }
            };

            var result = (from int val in arry select val).Sum();
            Console.WriteLine("Sum of Multidimentional array:= {0}", result);
        }
        //Join two string arrays with distinct values
        static void TwoStringArraysWithDistinct()
        {
            string[] first = { "One", "Two" };
            string[] two = { "Three", "One" };
            first.Union(two).ToList().ForEach(Console.WriteLine);
        }
    }
}
