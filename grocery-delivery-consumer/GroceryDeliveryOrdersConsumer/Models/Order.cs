using System.Collections.Generic;

namespace GroceryDeliveryOrdersConsumer.Models
{
    public class Order
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<CartItem> Cart { get; set; }
        public decimal Total { get; set; }
    }
}