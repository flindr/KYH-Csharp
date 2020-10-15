using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    class Inventory : IEnumerable<Item>, IList<Item>
    {
        public List<Item> Items { get; private set; }
        public bool IsReadOnly => ((ICollection<Item>)Items).IsReadOnly;
        public int Count => ((ICollection<Item>)Items).Count;
        public Item this[int index] { get => ((IList<Item>)Items)[index]; set => ((IList<Item>)Items)[index] = value; }

        public Inventory()
        {
            Items = new List<Item>();
        }

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public new string[] ToString()
        {
            return Items.Select(item => item.ToString()).ToArray();
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IEnumerable<Item>)Items).GetEnumerator();
        }

        public int IndexOf(Item item)
        {
            return ((IList<Item>)Items).IndexOf(item);
        }

        public void Insert(int index, Item item)
        {
            ((IList<Item>)Items).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Item>)Items).RemoveAt(index);
        }

        public void Clear()
        {
            ((ICollection<Item>)Items).Clear();
        }

        public bool Contains(Item item)
        {
            return ((ICollection<Item>)Items).Contains(item);
        }

        public void CopyTo(Item[] array, int arrayIndex)
        {
            ((ICollection<Item>)Items).CopyTo(array, arrayIndex);
        }

        public bool Remove(Item item)
        {
            return ((ICollection<Item>)Items).Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Items).GetEnumerator();
        }
    }
}
