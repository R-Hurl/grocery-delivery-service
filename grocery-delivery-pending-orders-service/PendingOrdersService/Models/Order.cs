using System;

namespace PendingOrdersService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }
        public int CustomerId { get; set; }
        public string OrderStatus { get; set; }
        public decimal Total { get; set; }
    }
}