using System;
using System.Collections.Generic;

namespace HashTable
{
    public class MyMapNode<G, V>
    {
        internal readonly int size;
        private readonly LinkedList<KeyValue<G, V>>[] items;

        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<G, V>>[size];
        }

        public struct KeyValue<G, v>
        {
            public G Key { get; set; }
            public v Value { get; set; }
        }

        public void Add(G key, V value)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<G, V>> linkedList = GetLinkedList(position);
            KeyValue<G, V> item = new KeyValue<G, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }

        public V Get(G key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<G, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<G, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        protected int GetArrayPosition(G key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }

        protected LinkedList<KeyValue<G, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<G, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<G, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }

        public void Remove(G key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<G, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            KeyValue<G, V> foundItem = default(KeyValue<G, V>);
            foreach (KeyValue<G, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
                linkedList.Remove(foundItem);
        }
    }
}