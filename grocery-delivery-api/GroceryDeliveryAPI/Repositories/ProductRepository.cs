
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryDeliveryAPI.Models;
using GroceryDeliveryAPI.Repositories.Interfaces;

namespace GroceryDeliveryAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>
        {
            new Product
            {
                ID = 1,
                CategoryId = 1,
                Name = "Milk",
                Description = "Stuff you put in cereal"
            },
            new Product
            {
                ID = 2,
                CategoryId = 1,
                Name = "Yogurt",
                Description = "Fermented Milk"
            },
            new Product
            {
                ID = 3,
                CategoryId = 1,
                Name = "Sour Cream",
                Description = "Sour Fermented Milk"
            },
            new Product
            {
                ID = 4,
                CategoryId = 1,
                Name = "Cheddar Cheese",
                Description = "Solid Milk"
            },
            new Product
            {
                ID = 5,
                CategoryId = 1,
                Name = "Swiss Cheese",
                Description = "It's Swiss"
            },
            new Product
            {
                ID = 6,
                CategoryId = 2,
                Name = "Ground Beef",
                Description = "Comes from cows"
            },
        };
        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(short categoryId)
        {
            var products = _products.Where(product => product.CategoryId == categoryId).ToList();
            return Task.FromResult<IEnumerable<Product>>(products);
        }
    }
}