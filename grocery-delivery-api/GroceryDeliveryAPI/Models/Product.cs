namespace GroceryDeliveryAPI.Models
{
    public class Product
    {
        public short ID { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
