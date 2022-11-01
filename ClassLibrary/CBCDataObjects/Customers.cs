using System;
namespace ClassLibrary.CBCDataObjects
{
    public class Customers : List<Customer>
    {
        private int id = 0;
        public Customers() { }
        public Customer AddNew (Customer customer)
        {
            id++;
            customer.CustomerID = id;
            this.Add(customer);
            return customer;
        }
    }
}

