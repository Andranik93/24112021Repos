namespace DictionaryImplementation2
{
    public struct Entry<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public int Next { get; set; } 

        public Entry(TKey key,TValue value)
        {
            Next = -1;
            Key = key;
            Value = value;
        }
    }
}
