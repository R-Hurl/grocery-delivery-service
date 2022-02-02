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
        private readonly IConsumer<string, string> _consumer;

        public OrdersConsumerService(ILogger<OrdersConsumerService> logger, IConsumer<string, string> consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);
                    _logger.LogInformation($"Key: {consumeResult.Message.Key} - Value: {consumeResult.Message.Value}");
                }
                catch (Exception ex)
                {
                    _logger.LogError(new EventId(1000, "OrdersConsumerException"), ex, "Error Occured Consuming Order", null);
                }
            }
        }

        public override void Dispose()
        {
            _consumer.Dispose();
            base.Dispose();
        }
    }
}
