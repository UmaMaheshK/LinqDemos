using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemos
{
    class ForEach
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 0, 1, 2, 3, 4, 5 };
            Console.WriteLine("ForEach with action delegate");
            arr.ToList().ForEach(Console.WriteLine);//0 1 2 3 4 5
            Console.WriteLine("ForEach with anonymous method");
            arr.ToList().ForEach(x => { Console.WriteLine(x); });//0 1 2 3 4 5

            arr.ToList().ForEach(x => { x = (x + 1); });//List not updated
            arr.ToList().ForEach(Console.WriteLine); //0 1 2 3 4 5
            Console.WriteLine("Array.ForEach with action delegate");
            Array.ForEach(arr, Console.WriteLine);//0 1 2 3 4 5
            Console.WriteLine("Array.ForEach with action delegate after updated");
            Array.ForEach(arr, x => { x = x * 10; Console.WriteLine(x); });//Array updated
            //Array.ForEach(arr, Console.WriteLine);//0 10 20 30 40 50
            arr.All(x => { x = x + 10; return true; });//array not updated
            arr.ToList().ForEach(Console.WriteLine); //0 1 2 3 4 5

            arr.Select(x => { x = x + 1; return x; }).ToList().ForEach(Console.WriteLine);//1 2 3 4 5 6

            List<int> list = new List<int> { 0, 1, 2, 3, 4, 5 };
            list.ForEach(x => { x = (x + 1); });//List not updated
            list.ForEach(Console.WriteLine);//0 1 2 3 4 5


            Console.WriteLine("-----Working with Complex Type-----");

            List<MyClass> cls = new List<MyClass> { new MyClass(), new MyClass(), new MyClass(), new MyClass() };
            cls.ForEach(x => Console.WriteLine(x.Id));// 0 0 0 0
            cls.ForEach(x => x.Id = 10);//List updated
            cls.ForEach(x => Console.WriteLine(x.Id));// 10 10 10 10
            cls.All(x => { x.Id = 100; return true; });//List updated
            cls.ForEach(x => Console.WriteLine(x.Id));// 100 100 100 100

        }
    }
    class MyClass
    {
        public int Id { get; set; }
    }
}
