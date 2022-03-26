using System;

namespace GroceryDeliveryAPI.DTOs
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }
        public string OrderStatus { get; set; }
        public decimal Total { get; set; }
    }
}