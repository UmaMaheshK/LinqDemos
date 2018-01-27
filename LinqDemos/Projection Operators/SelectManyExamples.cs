using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqDemos.Projection_Operators
{
    class SelectManyExamples
    {
        static void Main(string[] args)
        {
            Example6();
        }

        static void Example1()
        {
            string[] fruitsArray = { "Apple", "Banana", "Grapes" };
            fruitsArray.SelectMany(e => e).ToList().ForEach(Console.WriteLine);//AppleBananaGrapes
            //Console.WriteLine(new string('*', 20));
        }
        static void Example2()
        {
            string[] fruitsArray = { "Apple", "Banana", "Grapes" };
            fruitsArray.SelectMany(e => e.Select(x => x.ToString().ToUpper())).ToList().ForEach(Console.WriteLine);//APPLEBANANAGRAPES
        }
        static void Example3()
        {
            //Cross join
            char[] uCase = { 'A', 'B', 'C', 'D' };
            char[] lCase = { 'a', 'b', 'c', 'd' };
            uCase.SelectMany(u => lCase, (u, l) => u + " " + l).ToList().ForEach(Console.WriteLine);
        }
        static void Example4()
        {
            string[] SubjectArray = { "PHP", "Java", "CSS" };
            var result = SubjectArray.SelectMany(x => x.ToCharArray());
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        static void Example5()
        {
            List<List<string>> products = new List<List<string>>
                                {
                                    new List<string> { "Apple", "Banana", "Grapes" },
                                    new List<string> { "Coke", "Milk", "Fanta" },
                                    new List<string> { "Mobile", "TV", "Tablet" }
                                 };

            List<string> allProducts = products.SelectMany(x => x).ToList();
            //Or if we want we can project the inner list too, both are same  
            List<string> allProductsByProjection = products.SelectMany(x => x.Select(z => z)).ToList();
        }
        static void Example6()
        {
            //Second overloaded method
            List<List<int>> numbers = new List<List<int>>
                                        {
                                              new List<int> { 23, 45, 66 },  //0 Index
                                              new List<int> { 12, 88, 32 }  //1 Index
                                        };
            numbers.SelectMany((x, i) => x.Select(z => z + i)).ToList().ForEach(Console.WriteLine); //23 45 66 13 89 33
        }
        static void Example8()
        {
            var result = MonthlySales.GetMonthlySales().SelectMany((x, i) => x.Sales.Select(z => z.Value + i));
        }
        static void Example7()
        {
            List<MonthlySales> result = MonthlySales.GetMonthlySales()
           .SelectMany(x => x.Sales, (MonthlySalesObj, SalesObj) => new
            {
                MonthlySalesObj.Month,
                SalesObj
            }
             ).GroupBy(x => new { x.Month, ProductName = x.SalesObj.Key })
             .Select(x => new MonthlySales
             {
                 Month = x.Key.Month,
                 Sales = new Dictionary<string, double> { { x.Key.ProductName, x.Sum(z => z.SalesObj.Value) } }
             }).ToList();
        }
        public class MonthlySales
        {
            public string Month { get; set; }
            public Dictionary<string, double> Sales { get; set; }
            public static List<MonthlySales> GetMonthlySales()
            {
                var monthlySales = new List<MonthlySales>
{
    new MonthlySales { Month= "June", Sales = new Dictionary<string,double>
                                          {
                                              { "Apple", 20 },
                                              { "Grapes", 40 }
                                          }
                     }, //Index 0 
    new MonthlySales { Month= "June", Sales =new Dictionary<string,double>
                                         {
                                              { "Banana", 10 },
                                              {"Apple", 30} }
                     },  //Index 1
    new MonthlySales { Month= "December", Sales =new Dictionary<string,double>
                                        {
                                              { "Mango", 10 },
                                              {"Banana", 20} }
                     },  //Index 2
    new MonthlySales { Month= "December", Sales =new Dictionary<string,double>
                                        {
                                              {"Banana", 40} }
                     },  //Index 3
};
                return monthlySales;
            }
        }
    }
}
