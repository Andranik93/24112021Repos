using System.Collections;
using System.Collections.Generic;

namespace LinkedListImplementation
{
    public class LinkedList<T> : IEnumerable<T>
    {
        #region Variables
        private int count;
        public int Count { get { return count; } }
        public LinkedListNode<T> First { get { return head; } }
        LinkedListNode<T> head;
        LinkedListNode<T> tail;
        #endregion

        #region Constructors
        public LinkedList()
        {

        }
        #endregion

        #region Methods
        public void AddFirst(LinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }
            count++;
        }

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new(value);
            AddFirst(newNode);
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new(value);
            AddLast(newNode);
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
            count++;
        }

        public void AddAfter(LinkedListNode<T> currentNode, LinkedListNode<T> newNode)
        {
            var afterCopy = currentNode.Next;
            currentNode.Next = newNode;
            newNode.Previous = currentNode;

            count++;

            if (afterCopy == null)
            {
                tail = newNode;
                return;
            }

            afterCopy.Previous = newNode;
            newNode.Next = afterCopy;
        }

        public void AddAfter(LinkedListNode<T> exitingNode, T value)
        {
            LinkedListNode<T> newNode = new(value);
            AddAfter(exitingNode, newNode);
        }

        public void AddBefore(LinkedListNode<T> currentNode, LinkedListNode<T> newNode)
        {
            //if (exitingNode != null)
            //{
            //    if (exitingNode.Previous != null)
            //    {
            //        LinkedListNode<T> NodeAfterExitingNode = exitingNode.Previous;
            //        exitingNode.Previous = newNode;
            //        newNode.Next = exitingNode;
            //        NodeAfterExitingNode.Next = newNode;
            //        newNode.Previous = NodeAfterExitingNode;
            //    }
            //    else
            //    {
            //        exitingNode.Previous = newNode;
            //        newNode.Next = exitingNode;
            //        head = newNode;
            //    }
            //    count++;
            //}


            var prevCopy = currentNode.Previous;

            currentNode.Previous = newNode;
            newNode.Next = currentNode;

            count++;

            if (prevCopy is null)
            {
                head = newNode;
                return;
            }

            newNode.Previous = prevCopy;
            prevCopy.Next = newNode;

        }

        public void AddBefore(LinkedListNode<T> exitingNode, T value)
        {
            LinkedListNode<T> newNode = new(value);
            AddBefore(exitingNode, newNode);
        }

        public void RemoveFirst()
        {
            if (head != null)
            {
                count--;
                if (head.Next != null)
                {
                    head = head.Next;
                    head.Previous = null;
                }
                else
                {
                    Clear();
                }
            }
        }

        public void RemoveLast()
        {
            if (tail != null)
            {
                count--;
                if (tail.Previous != null)
                {
                    tail = tail.Previous;
                    tail.Next = null;
                }
                else
                {
                    Clear();
                }
            }
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if ((int)(object)current.item == (int)(object)value)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public bool Contains(T value)
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                if ((int)(object)current.item == (int)(object)value)
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public void Remove(T item)
        {
            LinkedListNode<T> searchingNode = Find(item);
            if (searchingNode != null)
            {
                count--;
                if (searchingNode.Previous != null)
                {
                    searchingNode.Previous.Next = searchingNode.Next;
                    if (searchingNode.Next != null)
                    {
                        searchingNode.Next.Previous = searchingNode.Previous;
                    }
                    else
                    {
                        tail = searchingNode.Previous;
                    }
                }
                else
                {
                    if (searchingNode.Next != null)
                    {
                        head = head.Next;
                        head.Previous = null;
                    }
                    else
                    {
                        Clear();
                    }
                }
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //_current = head;
            //while (_current != null)
            //{
            //    yield return _current.item;
            //    _current = _current.Next;
            //}

            return new LinkedListEnumerator<T>(head, count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        #endregion
    }
}
