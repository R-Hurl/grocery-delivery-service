using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Confluent.Kafka;
using GroceryDeliverAPI.Models;
using GroceryDeliveryAPI.DTOs;
using GroceryDeliveryAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GroceryDeliverAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly string KAFKA_TOPIC = "orders";
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> SubmitOrder([FromBody] SubmittedOrder order)
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
                        Value = JsonSerializer.Serialize(order)
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

            return await Task.FromResult(orderNumber);
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersAsync()
        {
            return await _orderRepository.GetOrdersAsync();
        }

        [HttpGet]
        [Route("{controller}/{orderId}")]
        public async Task<ActionResult<List<OrderItemDTO>>> GetOrderItemsAsync(string orderId)
        {
            return await _orderRepository.GetOrderItemsAsync(orderId);
        }
    }
}