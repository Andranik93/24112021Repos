using System;
using System.Linq;

namespace LinkedListImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(5);
            linkedList.AddFirst(6);
            linkedList.AddFirst(7);
            linkedList.AddFirst(8);
            linkedList.AddFirst(9);

            linkedList.AddBefore(linkedList.First, 15);
            linkedList.AddBefore(linkedList.First, 6);
            linkedList.AddBefore(linkedList.First, 7);
            linkedList.AddBefore(linkedList.First, 8);
            linkedList.AddBefore(linkedList.First, 9);


            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine();
            Console.WriteLine();
            if (linkedList.Contains(7))
            {
                linkedList.Remove(7);
            }


            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();

        }
    }
}
