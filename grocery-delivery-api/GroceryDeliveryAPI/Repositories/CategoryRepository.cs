using GroceryDeliveryAPI.DataRepository.Repositories.Interfaces;
using GroceryDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryDeliveryAPI.DataRepository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<Category> _categories = new List<Category>
        {
            new Category
            {
                ID = 1,
                CategoryName = "Dairy"
            },
            new Category
            {
                ID = 2,
                CategoryName = "Meat"
            },
            new Category
            {
                ID = 3,
                CategoryName = "Fruit"
            }
        };
        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await Task.FromResult<IEnumerable<Category>>(_categories);
        }
    }
}
