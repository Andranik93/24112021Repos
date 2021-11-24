namespace LinkedListImplementation
{
    public class LinkedListNode<T>
    {
        #region Variables

        public T item;
        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
        #endregion

        #region Constructors
        public LinkedListNode(T value)
        {
            item = value;
        } 
        #endregion
    }
}
