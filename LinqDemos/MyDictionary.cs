using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemos
{
    class MyDictionary
    {
        static void Main(string[] args)
        {
            DictionaryMethod();
            Console.WriteLine();
            IDictionaryMethod();
        }

        private static void DictionaryMethod()
        {
            //Declare Dictionary
            Dictionary<string, int> age = new Dictionary<string, int>();

            //Add keys and values
            age.Add("Uma", 37);
            age.Add("Nynika", 1);

            //age.Add("Uma", 30);//ArgumentException already exist(Uma).

            //If exist modify otherwise add new key.
            age["Nynika"] = 120; //modify the value 1 to 120;

            //If exist modify otherwise add new key.
            age["Suma"] = 130;//key is not there so it is added to dictionary.
            age.Add("Riyaan", 100);
            age.Add("Mahesh", 90);

            Console.WriteLine("Display all Dictionary elements");
            foreach (var item in age)
                Console.WriteLine("age[{0}] = {1}", item.Key, item.Value);

            Console.WriteLine("\nKeyValuePair");
            foreach (KeyValuePair<string, int> item in age)
                Console.WriteLine("age[{0}] = {1}", item.Key, item.Value);

            //1 way 
            //Get all keys 
            Console.Write("1 way Keys :");
            foreach (var item in age.Keys)
                Console.Write(" {0}", item);

            Console.WriteLine();

            //2 way 
            //Get all keys 
            Dictionary<string, int>.KeyCollection keys = age.Keys;
            Console.Write("2 way Keys :");
            foreach (var item in keys)
                Console.Write(" {0}", item);
            Console.WriteLine();

            //1 way 
            //Get all Vaues 
            Console.Write("1 way Vaues :");
            foreach (var item in age.Values)
                Console.Write(" {0}", item);

            Console.WriteLine();

            //2 way all values
            Dictionary<string, int>.ValueCollection vals = age.Values;
            Console.Write("2 way values :");
            foreach (var item in vals)
                Console.Write(" {0}", item);
            Console.WriteLine();

            //TryGetValue
            // 1 way
            int newAge = 0;
            string key = "Mahesh";
            age.TryGetValue(key, out newAge);
            Console.WriteLine("1 way TryGetVaue:= age[{0}] = {1}", key, newAge);

            // 2 way
            string key1 = "Mahesh";
            age.TryGetValue(key1, out int newAge1);
            Console.WriteLine("2 way TryGetVaue:= age[{0}] = {1}", key1, newAge1);

            //ContainsKey
            Console.WriteLine("ContainsKey : {0} key := {1}", key, age.ContainsKey(key));
            //ContainsValue
            Console.WriteLine("ContainsValue : {0} Value := {1}", newAge, age.ContainsValue(newAge));//newAge = 90

            //if exists remove the key
            age.Remove("ii");
            //Remove all keys and values from dictionary.
            age.Clear();
        }

        static void IDictionaryMethod()
        {
            //Declare Dictionary
            IDictionary<string, int> age = new Dictionary<string, int>();

            //Add keys and values
            age.Add("Uma", 37);
            age.Add("Nynika", 1);

            //age.Add("Uma", 30);//ArgumentException already exist(Uma).

            //If exist modify otherwise add new key.
            age["Nynika"] = 120; //modify the value 1 to 120;

            //If exist modify otherwise add new key.
            age["Suma"] = 130;//key is not there so it is added to dictionary.
            age.Add("Riyaan", 100);
            age.Add("Mahesh", 90);

            Console.WriteLine("Display all Dictionary elements");
            foreach (var item in age)
                Console.WriteLine("age[{0}] = {1}", item.Key, item.Value);

            Console.WriteLine("\nKeyValuePair");
            foreach (KeyValuePair<string, int> item in age)
                Console.WriteLine("age[{0}] = {1}", item.Key, item.Value);

            //1 way 
            //Get all keys 
            Console.Write("1 way Keys :");
            foreach (var item in age.Keys)
                Console.Write(" {0}", item);

            Console.WriteLine();

            //2 way 
            //Get all keys 
            ICollection<string> keys = age.Keys;
            Console.Write("2 way Keys :");
            foreach (var item in keys)
                Console.Write(" {0}", item);
            Console.WriteLine();

            //1 way 
            //Get all Vaues 
            Console.Write("1 way Vaues :");
            foreach (var item in age.Values)
                Console.Write(" {0}", item);

            Console.WriteLine();

            //2 way all values
            ICollection<int> vals = age.Values;
            Console.Write("2 way values :");
            foreach (var item in vals)
                Console.Write(" {0}", item);
            Console.WriteLine();

            //TryGetValue
            // 1 way
            int newAge = 0;
            string key = "Mahesh";
            age.TryGetValue(key, out newAge);
            Console.WriteLine("1 way TryGetVaue:= age[{0}] = {1}", key, newAge);

            // 2 way
            string key1 = "Mahesh";
            age.TryGetValue(key1, out int newAge1);
            Console.WriteLine("2 way TryGetVaue:= age[{0}] = {1}", key1, newAge1);

            //ContainsKey
            Console.WriteLine("ContainsKey : {0} key := {1}", key, age.ContainsKey(key));
            //no ContainsValue()
            //Console.WriteLine("ContainsValue : {0} Value := {1}", newAge, age.ContainsValue(newAge));//newAge = 90

            //if exists remove the key
            age.Remove("ii");
            Console.WriteLine("Dictionary with ForEach");
            age.ToList().ForEach(e => e.Key.ToString().ToUpper());
            foreach (var item in age.Keys)
                Console.WriteLine(item.ToString());
            //Remove all keys and values from dictionary.
            age.Clear();
        }

        static void DictionaryInitialization()
        {
            Dictionary<string, int> age = new Dictionary<string, int>();
            age.Add("A", 65);
            age.Add("B", 66);
            age.Add("C", 67);
            age.Add("D", 68);
            age.Add("E", 69);

            Dictionary<string, int> age1 = new Dictionary<string, int>() { };
            age["A"] = 65;
            age["B"] = 66;
            age["C"] = 67;
            age["D"] = 68;
            age["E"] = 69;

            Dictionary<char, int> age2 = new Dictionary<char, int>
                                            {
                                                { 'A', 65 },
                                                { 'B', 66 },
                                                { 'C', 67 },
                                                { 'D', 68 },
                                                { 'E', 69 }
                                            };
            //C# 6.0 feature
            Dictionary<char, int> ascii = new Dictionary<char, int>
            {
                ['A'] = 65,
                ['B'] = 66,
                ['C'] = 67,
                ['D'] = 68,
                ['E'] = 69
            };
        }

        static void ArrayToDictionary()
        {
            string[] arr = new string[] { "One", "Two" };
            var dict = arr.ToDictionary(item => item, item => true);
            foreach (var pair in dict)
            {
                Console.WriteLine("{0}, {1}", pair.Key, pair.Value);
            }
        }
    }
}