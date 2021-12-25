using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using GroceryDeliveryOrdersConsumer.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GroceryDeliveryOrdersConsumer
{
    public class OrdersConsumerService : BackgroundService
    {
        private readonly ILogger<OrdersConsumerService> _logger;
        private readonly ConsumerConfig _consumerConfig;
        private readonly IEnumerable<string> _topics = new List<string> { "orders" };

        public OrdersConsumerService(ILogger<OrdersConsumerService> logger)
        {
            _logger = logger;
            _consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "order-consumers",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var consumer = new ConsumerBuilder<string, string>(_consumerConfig).Build())
            {
                consumer.Subscribe(_topics);

                while (!stoppingToken.IsCancellationRequested)
                {
                    var consumeResult = consumer.Consume(stoppingToken);
                    string orderNumber = consumeResult.Message.Key;
                    var order = JsonConvert.DeserializeObject<Order>(consumeResult.Message.Value);

                    Console.WriteLine($"Incoming Order: OrderNumber - {orderNumber} Order: {order}");
                }

                consumer.Close();
            }
        }
    }
}
