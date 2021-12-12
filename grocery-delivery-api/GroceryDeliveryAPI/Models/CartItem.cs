using GroceryDeliveryAPI.Models;

namespace GroceryDeliverAPI.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}