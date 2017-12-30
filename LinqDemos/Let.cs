using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemos
{
    class Let
    {
        static void Main(string[] args)
        {
            //WithOut_LetExample1();
            //LetExample2();
            //LetExample3();
            //LetExample4();
            LetExample5();
        }

        private static void WithOut_LetExample1()
        {
            int[] ages = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var result = from a in ages
                         where a > 5
                         select a;

            result.ToList().ForEach(Console.WriteLine);//6,7,8,9
        }

        private static void LetExample2()
        {
            Console.WriteLine("Using Let keywork");
            var numbers = Enumerable.Range(1, 100);
            var evenNumbers = from n in numbers
                              let IsEven = n % 2 == 0
                              where IsEven
                              select n;

            evenNumbers.ToList().ForEach(Console.WriteLine);//2,4,6,8,10...98,100
        }

        private static void LetExample3()
        {
            Console.WriteLine("Using Let keywork");
            var numbers = Enumerable.Range(1, 100);
            var evenNumbers = from n in numbers
                              let IsEven = n % 2 == 0
                              where IsEven
                              select new { Number = n, Even = IsEven };

            evenNumbers.ToList().ForEach(Console.WriteLine);//{Number=2,Even=True}....{Number=100,Even=True}
        }
        private static void LetExample4()
        {
            string[] strings =
                {
                    "A penny saved is a penny earned.",
                    "The early bird catches the worm.",
                    "The pen is mightier than the sword."
                };

            var result = from st in strings
                         let words = st.Split(' ')
                         from word in words
                         let w = word.ToLower()
                         where w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u'
                         select w;
            result.ToList().ForEach((e) => { Console.WriteLine("\"{0}\" Starts with a vowel", e); });

            /* Output:
               "A" starts with a vowel
               "is" starts with a vowel
               "a" starts with a vowel
               "earned." starts with a vowel
               "early" starts with a vowel
               "is" starts with a vowel
           */
        }
        private static void LetExample5()
        {
            IEnumerable<int> numbers = Enumerable.Range(1, 100);

            var result = from num in numbers
                         where num % 5 == 0 //&& num % 2 != 0
                         select num into oddNumbers
                         let IsOdd = oddNumbers % 2 != 0
                         where IsOdd
                         select oddNumbers;

            result.ToList().ForEach(Console.WriteLine);
        }
    }
}
