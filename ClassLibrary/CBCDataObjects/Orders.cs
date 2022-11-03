using System;
using ClassLibrary.CBCDataObjects;
namespace ClassLibrary.CBCDataObjects
{
    public class Orders : List<Order>
    {
        private int id = 0;

        public Orders()
        {
        }
        public Order AddNew(Order order)
        {
            id++;
            order.OrderID = id;
            this.Add(order);
            return order;
        }
    }
}

