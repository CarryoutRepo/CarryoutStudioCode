using System;
namespace ClassLibrary.CBCDataObjects
{
    public class Item
    {
        public int ItemID { get; set; }
        public String? SKU { get; set; }
        public String? Description { get; set; }
        public String? ShortDescription { get; set; }
        public String? SizeDescription { get; set; }
        public String? InteternalDescription { get; set; }

        public Item(
            int itemId,
            String? sku,
            String? description,
            String? shortDescription,
            String? sizeDescription,
            String? inteternalDescription)
        {
            SKU = sku;
            Description = description;
            ShortDescription = shortDescription;
            SizeDescription = sizeDescription;
            InteternalDescription = inteternalDescription;
        }
    }
}

