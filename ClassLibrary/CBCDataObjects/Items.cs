using System;
using ClassLibrary.CBCDataObjects;
namespace ClassLibrary.CBCDataObjects
{
    public class Items : List<Item>
    {
        private int id = 0;
        public Items() { }
        public Item AddNew(Item item)
        {
            item.ItemID = id++;
            this.Add(item);
            return item;
        }
            
    }
}

