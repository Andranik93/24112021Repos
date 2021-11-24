using System;

namespace DictionaryImplementation2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("first", 1);
            dict.Add("second", 2);
            dict.Add("third", 3);
            dict.Add("fourth", 4);
            dict.Add("fifth", 5);


            foreach (var element in dict)
            {
                Console.WriteLine(element.Key + ": " + element.Value);
            }

            Console.WriteLine(dict["first"]);
            Console.WriteLine(dict["second"]);
            Console.WriteLine(dict["third"]);
            Console.WriteLine(dict["fourth"]);
            Console.WriteLine(dict["fifth"]);


            dict["first"] = 9;
            Console.WriteLine(dict["first"]);


            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in dict.Keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();

            foreach (var item in dict.Values)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }
}