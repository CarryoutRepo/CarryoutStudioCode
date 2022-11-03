using System;
namespace ClassLibrary.CBCDataObjects
{
    public class Item
    {
        public int ItemID { get; set; }
        public String? SKU { get; set; }
        public String? Description { get; set; }
        public String? ShortDescription { get; set; }
        public String? Size { get; set; }
        public String? CBCCode { get; set; }
        public String? Note { get; set; }

        public Item(
            String? sku,
            String? description,
            String? shortDescription,
            String? size,
            String? cbcCode,
            String? note)
        {
            SKU = sku;
            Description = description;
            ShortDescription = shortDescription;
            Size = size;
            CBCCode = cbcCode;
            Note = note;
        }
    }
}

