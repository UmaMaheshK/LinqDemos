using System;
using System.Linq;

namespace LinqDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            //DistinctValueInString();
            Rewrite_ForEach_Loop();
        }

        //Distinct values in test
        static void DistinctValueInString()
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
    }
}
