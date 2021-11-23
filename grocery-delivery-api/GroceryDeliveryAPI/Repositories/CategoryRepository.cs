using GroceryDeliveryAPI.Models;
using GroceryDeliveryAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryDeliveryAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GroceryDeliveryServiceContext _groceryDeliveryServiceContext;

        public CategoryRepository(GroceryDeliveryServiceContext groceryDeliveryServiceContext)
        {
            _groceryDeliveryServiceContext = groceryDeliveryServiceContext;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            var categories = await _groceryDeliveryServiceContext.Categories.ToListAsync();
            return categories;
        }
    }
}
