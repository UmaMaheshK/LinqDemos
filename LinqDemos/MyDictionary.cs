using System;
using System.Collections.Generic;
namespace LinqDemos
{
    class MyDictionary
    {
        static void Main(string[] args)
        {
            DictionaryMethod();
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
    }
}