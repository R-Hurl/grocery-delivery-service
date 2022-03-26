using System.Collections.Generic;

namespace GroceryDeliverAPI.Models
{
    public class SubmittedOrder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<CartItem> Cart { get; set; }
        public decimal Total { get; set; }
    }
}