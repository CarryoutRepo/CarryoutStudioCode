using System;
using ClassLibrary.CBCTableObjects;

namespace ClassLibrary.CBCDataObjects
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public String Name { get; set; }
        public String? Telephone { get; set; }
        public String? Email { get; set; }
        public String? WKSOrderNumber { get; set; }
        public DateTime? PickupTime { get; set; }
            
        public Customer(int customerID, String name)
        {
            CustomerID = customerID;
            Name = name;
        }
    }
}

