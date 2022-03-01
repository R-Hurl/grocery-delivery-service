using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Confluent.Kafka;
using GroceryDeliveryOrdersConsumer.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GroceryDeliveryOrdersConsumer
{
    public class OrdersConsumerService : BackgroundService, IDisposable
    {
        private readonly ILogger<OrdersConsumerService> _logger;
        private readonly IConsumer<string, string> _consumer;
        private readonly IPendingOrdersService _pendingOrdersService;
        private readonly IMapper _mapper;

        public OrdersConsumerService(ILogger<OrdersConsumerService> logger, IConsumer<string, string> consumer,
        IPendingOrdersService pendingOrdersService, IMapper mapper)
        {
            _logger = logger;
            _consumer = consumer;
            _pendingOrdersService = pendingOrdersService;
            _mapper = mapper;
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

                    var order = JsonSerializer.Deserialize<GroceryDeliveryOrdersConsumer.Models.Order>(consumeResult.Message.Value);
                    var grpcOrder = _mapper.Map<Models.Order, Order>(order);

                    var pendingOrdersRequest = new PendingOrderRequest
                    {
                        OrderNumber = consumeResult.Message.Key,
                        Order = grpcOrder
                    };

                    var response = await _pendingOrdersService.RegisterPendingOrderAsync(pendingOrdersRequest);
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
