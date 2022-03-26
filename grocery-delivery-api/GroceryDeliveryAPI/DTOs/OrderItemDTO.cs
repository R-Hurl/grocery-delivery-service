using System;

namespace GroceryDeliveryAPI.DTOs
{
    public class OrderItemDTO
    {
        public ProductDTO Product { get; set; }
        public int Quantity { get; set; }
    }
}