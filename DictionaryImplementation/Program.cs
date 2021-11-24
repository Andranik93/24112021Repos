using System;

namespace DictionaryImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("first", 1);
            dictionary.Add("second", 2);
            dictionary.Add("third", 3);
            dictionary.Add("fourth", 4);
            dictionary.Add("fifth", 5);


            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine(keyValuePair.Key + " " + keyValuePair.Value);
            }

            Console.WriteLine();
            Console.WriteLine();

            dictionary.Remove("first");

            foreach (var keyValuePair in dictionary)
            {
                Console.WriteLine(keyValuePair.Key + " " + keyValuePair.Value);
            }



        }
    }
}
