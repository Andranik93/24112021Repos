using System;
using System.Collections;
using System.Collections.Generic;

namespace StackImplementation
{
    class Stack<T> : IEnumerable<T>
    {
        #region Variables
        readonly LinkedListImplementation.LinkedList<T> linkedList = new();
        public int Count => linkedList.Count;
        #endregion

        #region Constructors
        public Stack()
        {

        }
        #endregion

        #region Methods
        public void Push(T value)
        {
            linkedList.AddFirst(value);
        }

        public T Pop()
        {
            if (linkedList.First != null)
            {
                var value = linkedList.First.item;
                linkedList.RemoveFirst();
                return value;
            }
            Console.WriteLine("The stack is empty!");
            return default;
        }

        public T Peek()
        {
            if (linkedList.First != null)
            {
                return linkedList.First.item;
            }
            Console.WriteLine("The stack is empty!");
            return default;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return linkedList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this).GetEnumerator();
        } 
        #endregion
    }
}
