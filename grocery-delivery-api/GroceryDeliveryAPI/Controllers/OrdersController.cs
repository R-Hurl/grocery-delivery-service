using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using GroceryDeliverAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GroceryDeliverAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly string KAFKA_TOPIC = "orders";

        [HttpPost]
        public async Task<ActionResult<Guid>> SubmitOrder([FromBody] Order order)
        {
            // Generate order number.
            var orderNumber = Guid.NewGuid();

            // TODO: Add Logic to produce messages to Kafka.
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "broker:29092",
            };

            try
            {
                using (var producer = new ProducerBuilder<string, string>(producerConfig).Build())
                {
                    var message = new Message<string, string>
                    {
                        Key = orderNumber.ToString(),
                        Value = JsonConvert.SerializeObject(order)
                    };

                    // Write to ORDERS kafka topic
                    producer.Produce(KAFKA_TOPIC, message);

                    producer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return await Task.FromResult(Guid.NewGuid());
        }
    }
}