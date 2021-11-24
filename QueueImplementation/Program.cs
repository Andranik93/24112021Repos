﻿using System;

namespace QueueImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            foreach (var value in queue)
            {
                Console.WriteLine(value);
            }

        }
    }
}
