using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryImplementation
{
    public class Dictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        #region Variables
        private readonly LinkedList<TKey, TValue>[] Buckets;

        private readonly ICollection<KeyValuePair<TKey, TValue>> KeyValuePair;

        private int capacity;

        public int Count => capacity;

        public TValue this[TKey key]
        {
            get
            {
                var index = GetBucketsIndex(key);
                if (Buckets[index] != null)
                {
                    LinkedListNode<TKey, TValue> linkedListNode = Buckets[index].head;
                    while (linkedListNode != null)
                    {
                        if ((String)(object)linkedListNode.Key == (String)(object)key)
                        {
                            return linkedListNode.Value;
                        }
                        linkedListNode = linkedListNode.Next;
                    }
                }
                Console.WriteLine($"There is not value with {key} index");
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                var index = GetBucketsIndex(key);
                if (Buckets[index] != null)
                {
                    LinkedListNode<TKey, TValue> linkedListNode = Buckets[index].head;
                    while (linkedListNode != null)
                    {
                        if ((String)(object)linkedListNode.Key == (String)(object)key)
                        {
                            linkedListNode.Value = value;
                            return;
                        }
                        linkedListNode = linkedListNode.Next;
                    }
                    Buckets[index].AddLast(key, value);
                }
                else
                {
                    Buckets[index] = new LinkedList<TKey, TValue>();
                    Buckets[index].AddLast(key, value);
                }
                capacity++;
            }
        }
        #endregion

        #region Constructors
        public Dictionary()
        {
            Buckets = new LinkedList<TKey, TValue>[100];
            KeyValuePair = new Collection<KeyValuePair<TKey, TValue>>();
        }
        #endregion

        #region Methods
      
        public void Add(TKey key, TValue value)
        {
            var bucketsIndex = GetBucketsIndex(key);

            if (Buckets[bucketsIndex] == null)
            {
                Buckets[bucketsIndex] = new LinkedList<TKey, TValue>();
                Buckets[bucketsIndex].AddLast(key, value);
            }
            else
            {
                var KeyCollision = SearchKey(key, Buckets[bucketsIndex]);
                if (KeyCollision)
                {
                    return;
                }
                Buckets[bucketsIndex].AddLast(key, value);
            }
            capacity++;
            KeyValuePair.Add(new KeyValuePair<TKey, TValue>(key, value));
        }

        public bool Remove(TKey key)
        {
            var index = GetBucketsIndex(key);
            var isDeleted = Buckets[index]?.Remove(key);
            if ((bool)isDeleted)
            {
                KeyValuePair.Remove(new KeyValuePair<TKey, TValue>(key,Buckets[index].Value));
                return true;
            }
            return false;
        }

        private int GetBucketsIndex(TKey key)
        {
            var hashCode = key.GetHashCode();
            var bucketsIndex = (hashCode & int.MaxValue) % Buckets.Length;
            return bucketsIndex;
        }

        private static bool SearchKey(TKey key, LinkedList<TKey, TValue> linkedList)
        {
            LinkedListNode<TKey, TValue> linkedListNode = linkedList.head;
            while (linkedListNode != null)
            {
                if ((string)(object)linkedListNode.Key == (string)(object)key)
                {
                    return true;
                }
                linkedListNode = linkedListNode.Next;
            }
            return false;
        }

        public void Clear()
        {
            capacity = 0;
            for (int i = 0; i < Buckets.Length; i++)
            {
                    Buckets[i]?.Clear();
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return KeyValuePair.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion       
    }
}
