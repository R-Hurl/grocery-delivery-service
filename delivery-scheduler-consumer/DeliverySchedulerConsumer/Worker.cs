using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
using DeliverySchedulerConsumer.Models;
using DeliverySchedulerConsumer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DeliverySchedulerConsumer
{
    public class Worker : BackgroundService, IDisposable
    {
        private readonly IConsumer<string, string> _consumer;
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;

        private const string PENDING_ORDER_STATUS = "P";

        public Worker(IConsumer<string, string> consumer, ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _consumer = consumer;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Yield();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var consumeResult = _consumer.Consume(stoppingToken);
                    var order = JsonSerializer.Deserialize<DebeziumOrder>(consumeResult.Message.Value);
                    if (order?.Payload?.After?.OrderStatus == PENDING_ORDER_STATUS)
                    {

                        Guid.TryParse(order?.Payload?.After?.OrderId, out var orderId);
                        _logger.LogInformation($"About to set Order Status to Delivered for OrderId: {orderId}");
                        // Simulate Delay
                        await Task.Delay(5000);

                        using (IServiceScope scope = _serviceProvider.CreateScope())
                        {
                            IOrderRepository orderRepository =
                                scope.ServiceProvider.GetRequiredService<IOrderRepository>();

                            // Set order status to delivered
                            await orderRepository.SetOrderStatusToScheduledForDeliveryAsync(orderId);
                        }
                    }
                }
                catch (OperationCanceledException ex)
                {
                    _logger.LogError(new EventId(10002, "OperationCancelledException"), ex, "Cancellation Requested in Delivery Scheduler Consumer", null);
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(new EventId(10001, "DeliverySchedulerConsumerException"), ex, "Exception occurred consuming order from Kafka", null);
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