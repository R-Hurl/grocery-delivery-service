
using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryDeliveryAPI.Models;
using GroceryDeliveryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroceryDeliveryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ResponseCache(NoStore = false, Location = ResponseCacheLocation.Any, Duration = 60)]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync()
        {
            return Ok(await _categoryRepository.GetCategoriesAsync());
        }
    }
}