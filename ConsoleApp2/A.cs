using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class A<T>
    {
        public static int Id = 1;
        public void Increment()
        {
            Id++;
        }
        public void Print()
        {
            Console.WriteLine(Id);
        }
    }
}
