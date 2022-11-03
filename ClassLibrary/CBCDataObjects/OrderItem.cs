using System;
namespace ClassLibrary.CBCDataObjects
{
    public class OrderItem
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }

        public OrderItem(int orderItemId, int orderId, int itemId)
        {
            OrderItemID = orderItemId;
            OrderID = orderId;
            ItemID = itemId;
        }
    }
}

