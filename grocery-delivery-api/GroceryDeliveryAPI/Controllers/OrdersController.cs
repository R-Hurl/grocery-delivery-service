using System;
using System.Threading.Tasks;
using GroceryDeliverAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryDeliverAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpPost]
        public async Task<ActionResult<Guid>> SubmitOrder([FromBody] Order order)
        {
            // TODO: Add Logic to produce messages to Kafka.

            return await Task.FromResult(Guid.NewGuid());
        }
    }
}