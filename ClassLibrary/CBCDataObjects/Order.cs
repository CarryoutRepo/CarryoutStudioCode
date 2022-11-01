using System;
namespace ClassLibrary.CBCDataObjects
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public String? SquareID { get; set; }

        public Order() { }
        public Order(int orderId, int customerId, String? squareId = null)
        {
            OrderID = orderId;
            CustomerID = customerId;
            SquareID = squareId;
        }
    }
}

