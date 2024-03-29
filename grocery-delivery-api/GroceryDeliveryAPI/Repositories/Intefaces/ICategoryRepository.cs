using GroceryDeliveryAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryDeliveryAPI.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
