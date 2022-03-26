using System;

namespace GroceryDeliveryAPI.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Guid OrderId { get; set; }
    }
}