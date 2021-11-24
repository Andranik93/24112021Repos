using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryImplementation
{
    public class LinkedListNode<Tkey,Tvalue>
    {
        public Tkey Key { get; set; }
        public Tvalue Value { get; set; }
        public LinkedListNode<Tkey, Tvalue> Next;
        public LinkedListNode<Tkey, Tvalue> Previous;
        public LinkedListNode(Tkey tkey,Tvalue tvalue)
        {
            Key = tkey;
            Value = tvalue;
        }
    }
}
