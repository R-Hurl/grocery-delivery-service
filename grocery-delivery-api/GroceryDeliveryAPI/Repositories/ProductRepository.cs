
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryDeliveryAPI.Models;
using GroceryDeliveryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GroceryDeliveryAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GroceryDeliveryServiceContext _groceryDeliveryServiceContext;

        public ProductRepository(GroceryDeliveryServiceContext groceryDeliveryServiceContext)
        {
            _groceryDeliveryServiceContext = groceryDeliveryServiceContext;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(short categoryId)
        {
            var products = await _groceryDeliveryServiceContext.Products.Where(product => product.CategoryId == categoryId).ToListAsync();
            return products;
        }
    }
}