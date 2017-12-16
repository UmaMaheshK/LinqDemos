using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemos
{
    class Generics
    {
        static void Main(string[] args)
        {
            Pair<int> pair = new Pair<int>();
            pair.Add(23); pair.Add(37); pair.Add(92);
            pair.Add(123);

            for (byte index = 0; index < pair.Length; index++)
                Console.WriteLine(pair.GetT(index));

            //Generic List
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };//using System.Collection.Generic
        }

        //Generic Class
        class Pair<T>
        {
            T[] arr = new T[3];
            byte currentIndex;

            public int Length { get { return arr.Length; } }

            public void Add(T t)
            {
                if (currentIndex == arr.Length)
                    ModifiedArray();
                arr[currentIndex++] = t;
            }

            public void AddRange(params T[] t)
            {
                foreach (var item in t)
                    Add(item);
            }

            private void ModifiedArray()
            {
                T[] newArr = new T[arr.Length + 1];
                Array.Copy(arr, newArr, currentIndex);
                arr = newArr;
            }

            public T GetT(byte index)
            {
                return arr[index];
            }
        }

        class MyGeneric
        {
            public static void Add<T1, T2>(T1 t1, T2 t2)
            {
                dynamic first = t1, two = t2;
                Console.WriteLine("Add := {0}", (first + two));
            }

            public static void Add<T>(T t1, T t2)
            {
                dynamic first = t1, two = t2;
                Console.WriteLine("Add := {0}", (first + two));
            }

            public static void Add<T>(params T[] t)
            {
                //Console.WriteLine("Sum := {0}", t.Sum(e=>e));
            }
        }
    }
}
