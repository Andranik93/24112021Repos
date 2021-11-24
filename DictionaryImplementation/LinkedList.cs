using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryImplementation
{
    public class LinkedList<TKey,TValue>
    {
        private int count;
        public TValue Value { get; set; }
        public int Count { get { return count; } }
        public LinkedListNode<TKey,TValue> head;
        public LinkedListNode<TKey, TValue> tail;



        public void AddLast(TKey key, TValue value)
        {
            LinkedListNode<TKey,TValue> newNode = new(key,value);
            AddLast(newNode);
        }

        public void AddLast(LinkedListNode<TKey, TValue> newNode)
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

        public LinkedListNode<TKey,TValue> Find(TKey key)
        {
            LinkedListNode<TKey, TValue> current = head;
            while (current != null)
            {
                if ((string)(object)current.Key == (string)(object)key)
                {
                    return current;
                }
                current = current.Next;
            }
            return default;
        }


        public bool Remove(TKey key)
        {
            LinkedListNode<TKey,TValue> searchingNode = Find(key);
            Value = searchingNode.Value;
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
                return true;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
    }
}
