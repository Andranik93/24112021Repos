using System.Collections;
using System.Collections.Generic;

namespace LinkedListImplementation
{
    class LinkedListEnumerator<T> : IEnumerator<T>
    {
        #region Variables
        int position = -1;
        public T Current => _linkedListNode.item;

        public bool IsFirst => position == 0;

        object IEnumerator.Current => _linkedListNode;

        LinkedListNode<T> _linkedListNode;

        int _count;
        #endregion

        #region Methods
        public LinkedListEnumerator(LinkedListNode<T> linkedListNode, int count)
        {
            _linkedListNode = linkedListNode;
            _count = count;
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            while (_linkedListNode != null)
            {
                position++;

                if (IsFirst)
                    return true;

                _linkedListNode = _linkedListNode.Next;

                return position < _count;
            }
            return false;
        }

        public void Reset()
        {
            position = -1;
        } 
        #endregion
    }
}
