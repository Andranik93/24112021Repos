using System;
using System.Collections;
using System.Collections.Generic;

namespace ListImplementation
{
    class List<T> : IList<T> where T : new()
    {
        #region Variables
        T[] array;
        int count;
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < count)
                {
                    return array[index];
                }
                else
                {
                    Console.WriteLine("Set: The index out of list borders");
                    return default;
                }
            }

            set
            {
                if (index > 0 && index < count)
                {
                    array[index] = value;
                }
                Console.WriteLine("Set: The index out of list borders");
            }
        }
        public int Count => count;
        public bool IsReadOnly => false; 
        #endregion

        #region Constructors
        public List()
        {
            array = new T[4];
        }
        public List(int amountOfElements)
        {
            array = new T[amountOfElements];
        }
        #endregion

        #region Methods
        public void Add(T item)
        {
            if (array.Length - 1 == count)
            {
                T[] newArray = new T[array.Length * 2];
                CopyTo(newArray, 0);
            }
            else
            {
                array[count++] = item;
            }
        }

        public void Clear()
        {
            array = null;
        }

        public bool Contains(T item)
        {
            var index = IndexOf(item);
            if (index > 0)
            {
                return true;
            }
            return false;
        }

        public void CopyTo(T[] newArray, int arrayIndex)
        {
            for (int i = arrayIndex; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)array.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if ((int)(object)array[i] == (int)(object)item)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            if (index >= 0 && index < count)
            {
                array[index] = item;
            }
            else
            {
                Console.WriteLine("Insert: The index out of list borders");
            }
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);
            if (index > 0)
            {
                array[index] = default;
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= 0 && index < count)
            {
                array[index] = default;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this).GetEnumerator();
        } 
        #endregion
    }
}
