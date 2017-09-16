using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            DistinctValueInString();
        }

        //Distinct values in test
        static void DistinctValueInString()
        {
            string text = "angular,.net,SQL,angular";
            text.Split(',').Distinct().ToList().ForEach(Console.WriteLine);
            //Console.WriteLine(result);
        }
    }
}
