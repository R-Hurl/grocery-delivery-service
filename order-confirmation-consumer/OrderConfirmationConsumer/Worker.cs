using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OrderConfirmationConsumer
{
    public class Worker : BackgroundService, IDisposable
    {
        private readonly IHubContext<OrderConfirmationHub> _orderConfirmationHub;
        private readonly IConsumer<string, string> _consumer;
        private readonly ILogger<Worker> _logger;

        public Worker(IHubContext<OrderConfirmationHub> orderConfirmationHub, IConsumer<string, string> consumer, ILogger<Worker> logger)
        {
            _orderConfirmationHub = orderConfirmationHub;
            _consumer = consumer;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);
                    _logger.LogInformation("Received entry from orders kafka topic", JsonSerializer.Serialize(consumeResult));
                    string orderId = consumeResult?.Message?.Key;
                    string message = $"Order: {orderId} received at {DateTime.Now}";
                    await _orderConfirmationHub.Clients.All.SendAsync("OrderConfirmationMessage", message);
                }
                catch (System.Exception ex)
                {
                    _logger.LogError(new EventId(10001, "OrderConfirmationConsumerException"), ex, "Exception occurred consuming order from Kafka", null);
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