using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace PendingOrdersService.Services
{
    class PendingOrdersService : PendingOrders.PendingOrdersBase
    {
        private readonly ILogger<PendingOrdersService> _logger;

        public PendingOrdersService(ILogger<PendingOrdersService> logger)
        {
            _logger = logger;
        }

        public override Task<PendingOrderReply> RegisterPendingOrder(PendingOrderRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Successfully called GRPC PendingOrdersService with the following request: {JsonSerializer.Serialize(request)}");
            var pendingOrderReply = new PendingOrderReply
            {
                Success = true
            };

            return Task.FromResult<PendingOrderReply>(pendingOrderReply);
        }
    }
}