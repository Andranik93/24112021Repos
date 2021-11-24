using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = new A<string>();
            //var b = new A<int>();
            //a.Increment();
            //b.Print();

            var ob1 = new { Name = "Art" };
            var ob2 = new { Name = "Art" };

            if (ob1==ob2)
            {
                Console.WriteLine("ob1==ob2 is true!");
            }
            else
            {
                Console.WriteLine("ob1==ob2 is false!");
            }

            if (ob1.Equals(ob2))
            {
                Console.WriteLine("b1.Equals(ob2) is true!");
            }
            else
            {
                Console.WriteLine("b1.Equals(ob2) is false!");
            }

            Console.Read();
        }
    }
}
