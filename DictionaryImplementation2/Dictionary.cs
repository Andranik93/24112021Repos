using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;

namespace DictionaryImplementation2
{
    class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        #region Variables

        public int?[] Buckets;

        private Entry<TKey, TValue>[] entries;
        public int IndexEntries { get; set; }

        private readonly ICollection<TKey> KeyCollection;

        private readonly ICollection<TValue> ValueCollection;

        public ICollection<KeyValuePair<TKey, TValue>> CollectionOfPairs;

        private readonly IList<int> FreeList;

        public TValue this[TKey key]
        {
            get
            {
                var hashCode = key.GetHashCode();
                var BucketsNum = (hashCode & int.MaxValue) % Buckets.Length;

                if (Buckets[BucketsNum] != null)
                {
                    var i = (int)Buckets[BucketsNum];
                    while (i != -1)
                    {
                        if (entries[i].Key.Equals(key))
                        {
                            return entries[i].Value;
                        }

                        //if ((string)(object)entries[i].Key == (string)(object)key)
                        //{
                        //    return entries[i].Value;
                        //}
                        i = entries[i].Next;
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
            set
            {
                var hashCode = key.GetHashCode();
                var BucketsNum = (hashCode & int.MaxValue) % Buckets.Length;

                if (Buckets[BucketsNum] != null)
                {
                    var i = (int)Buckets[BucketsNum];
                    while (i != -1)
                    {
                        if ((string)(object)entries[i].Key == (string)(object)key)
                        {
                            ValueCollection.Remove(entries[i].Value);
                            ValueCollection.Add(value);
                            CollectionOfPairs.Remove(new KeyValuePair<TKey, TValue>(key, entries[i].Value));
                            CollectionOfPairs.Add(new KeyValuePair<TKey, TValue>(key, value));

                            entries[i].Value = value;
                            return;
                        }
                        i = entries[i].Next;
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
        }

        public ICollection<TKey> Keys => KeyCollection;

        public ICollection<TValue> Values => ValueCollection;

        public int Count => IndexEntries;

        public bool IsReadOnly => true; 
        #endregion

        #region Constructors
        public Dictionary()
        {
            Buckets = new int?[100];
            entries = new Entry<TKey, TValue>[100];
            KeyCollection = new Collection<TKey>();
            ValueCollection = new Collection<TValue>();
            FreeList = new List<int>();
            CollectionOfPairs = new Collection<KeyValuePair<TKey, TValue>>();
        } 
        #endregion

        #region Methods

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Add(TKey key, TValue value)
        {

            if (!KeyCollection.Contains(key))
            {
                //var element = new KeyValuePair<TKey, TValue>(key, value);
                CollectionOfPairs.Add(new KeyValuePair<TKey, TValue>(key, value));


                var newEntry = new Entry<TKey, TValue>(key, value);
                KeyCollection.Add(key);
                ValueCollection.Add(value);

                var hashCode = key.GetHashCode();
                var BucketsNum = (hashCode & int.MaxValue) % Buckets.Length;

                if (Buckets[BucketsNum] != null)
                {
                    int i = (int)Buckets[BucketsNum];
                    while (i != -1)
                    {
                        i = entries[i].Next;
                    }
                    if (FreeList.Count != 0)
                    {
                        var entryIndex = FreeList.First();
                        FreeList.RemoveAt(entryIndex);
                        entries[entryIndex] = newEntry;
                    }
                    else
                    {
                        entries[IndexEntries++] = newEntry;
                    }
                }
                else
                {
                    if (FreeList.Count != 0)
                    {
                        var bucketIndex = FreeList.First();
                        FreeList.RemoveAt(bucketIndex);
                        Buckets[BucketsNum] = bucketIndex;
                        entries[bucketIndex] = newEntry;
                    }
                    else
                    {
                        Buckets[BucketsNum] = IndexEntries;
                        entries[IndexEntries] = newEntry;
                        IndexEntries++;
                    }
                }
                return;
            }
            throw new ArgumentException("The key already exist!");
        }

        public bool Remove(TKey key)
        {
            if (!KeyCollection.Contains(key))
            {
                KeyCollection.Remove(key);

                var hashCode = key.GetHashCode();
                var BucketsNum = (hashCode & int.MaxValue) % Buckets.Length;

                var previous = -1;

                for (int i = (int)Buckets[BucketsNum]; i >= 0; previous = i, i = entries[i].Next)
                {
                    if ((string)(object)entries[i].Key == (string)(object)key)
                    {
                        if (previous != -1)
                        {
                            entries[previous].Next = entries[i].Next;
                        }
                        else if (entries[i].Next != -1)
                        {
                            Buckets[BucketsNum] = entries[i].Next;
                        }
                        else
                        {
                            Buckets[BucketsNum] = null;
                        }
                        ValueCollection.Remove(entries[i].Value);
                        CollectionOfPairs.Remove(new KeyValuePair<TKey, TValue>(key, entries[i].Value));
                        entries[i].Key = default;
                        entries[i].Value = default;
                        entries[i].Next = -1;
                        FreeList.Add(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public void Clear()
        {
            KeyCollection.Clear();
            ValueCollection.Clear();

        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return CollectionOfPairs.GetEnumerator();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        } 
        #endregion
    }
}
