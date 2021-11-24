using System;
using System.Collections;
using System.Collections.Generic;

namespace QueueImplementation
{
    public class Queue<T> : IEnumerable<T>
    {
        #region Variables
        LinkedListImplementation.LinkedList<T> linkedList = new();
        public int Count => linkedList.Count;
        #endregion

        #region Constructors
        public Queue()
        {

        }

        #endregion

        #region Methods
        public void Enqueue(T value)
        {
            linkedList.AddLast(value);
        }

        public T Dequeue()
        {
            if (linkedList.First != null)
            {
                var value = linkedList.First.item;
                linkedList.RemoveFirst();
                return value;
            }
            Console.WriteLine("The queue is empty!");
            return default;
        }

        public T Peek()
        {
            if (linkedList.First != null)
            {
                return linkedList.First.item;
            }
            Console.WriteLine("The queue is empty!");
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
