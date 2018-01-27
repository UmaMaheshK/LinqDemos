using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemos.Projection_Operators
{
    class SelectExamples
    {
        static void Main(string[] args)
        {
            Example12();
        }

        static void Expample1()
        {
            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.Select(x => x * 2).ToList().ForEach(Console.WriteLine);//2 4,6,8
        }
        static void Expample2()
        {
            IList<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            Array.ForEach(numbers.Select(x => x * 2).ToArray(), Console.WriteLine);//2 4,6,8
        }
        static void Example3()
        {
            IList<string> numbers = new List<string> { "one", "two", "three", "four", "five" };
            numbers.Select(x => x.ToUpper()).ToList().ForEach(Console.WriteLine);//ONE TWO THREE FOUR FIVE
        }
        static void Example4()
        {
            IList<string> numbers = new List<string> { "one", "two", "three", "four", "five" };
            numbers.Select(x => x.Length).ToList().ForEach(Console.WriteLine);//3 3 5 4 4
        }
        static void Example5()
        {
            IList<string> numbers = new List<string> { "one", "two", "three", "four", "five" };
            numbers.Select(x => new { value = x, Lxngth = x.Length }).ToList().ForEach(Console.WriteLine);//{value : one,Length : 0 }.....
        }
        static void Example6()
        {
            IList<string> numbers = new List<string> { "one", "two", "three", "four", "five" };
            numbers.Select((x, i) => new { value = x, Index = i }).ToList().ForEach(Console.WriteLine);//{value : one,Index : 0 }.....
        }
        static void Example7()
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();//1 2 3 ....10
            numbers.ForEach(Console.WriteLine);
        }
        static void Example8()
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();//1 : ....10 :
            numbers.Select(x => x.ToString() + " : ").ToList().ForEach(Console.WriteLine);
        }
        static void Example9()
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();//5,10,15,20 ....100 :
            numbers.Select(x => { x = x * 5; return x; }).ToList().ForEach(Console.WriteLine);
        }

        static void Example10()
        {
            Student.GetStudentList().Select(x => { x.Salary = x.Salary - 10; return x; }).ToList()
                .ForEach(x => { Console.WriteLine("StudentId : = {0,-5} FullName : = {1,-20} Salary := {2,6:N4}", x.StudentId, x.FullName, x.Salary); });
        }
        static void Example11()
        {
            var result1 = Student.GetStudentList().Select(x => x.Subject).ToList();
            foreach (var item1 in result1)
            {
                foreach (var item2 in item1)
                {
                    Console.WriteLine(item2);
                }
            }
        }
        static void Example12()
        {
            List<List<int>> numbers = new List<List<int>>
            {
                new List<int> { 23, 45, 12, 56 },
                new List<int> { 78, 11, 7, 98 },
                new List<int> { 5, 23, 55, 29 },
                new List<int> { 17, 0, 3, 67 }
            };
            int count = numbers.First().Count;
            numbers.SelectMany(x => x)
                    .Select((x, i) => new { Value = x, Index = i % count })
                    .GroupBy(x => x.Index)
                    .Select(x => x.Sum(e => e.Value)).ToList().ForEach(Console.WriteLine);
        }

        class Student
        {
            public int StudentId { get; set; }
            public string FullName { get; set; }
            public decimal Salary { get; set; }
            public IList<string> Subject { get; set; }
            public static IList<Student> GetStudentList()
            {
                var result = new List<Student>
                {
                    new Student{ StudentId =100,FullName="Uma Mahesh",Salary=60000M,
                            Subject= new List<string>{"Math","Phy"}},
                    new Student{ StudentId =101,FullName="Nancy",Salary=30000M,
                            Subject= new List<string>{"Che","Phy" } },
                    new Student{ StudentId =102,FullName="Suma Latha",Salary=40000M,
                            Subject= new List<string>{"Hindi","Phy"}}
                };
                return result;
            }
        }
    }
}
