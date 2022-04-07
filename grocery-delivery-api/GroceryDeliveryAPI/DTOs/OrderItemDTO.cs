using System;

namespace GroceryDeliveryAPI.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}