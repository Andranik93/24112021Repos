using System;

namespace StackImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

        }
    }
}
