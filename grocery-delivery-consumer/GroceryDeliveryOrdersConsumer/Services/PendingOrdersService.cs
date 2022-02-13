using System;
using System.Threading.Tasks;
using GroceryDeliveryOrdersConsumer.Services.Interfaces;
using Grpc.Net.Client;

namespace GroceryDeliveryOrdersConsumer.Services
{
    class PendingOrdersService : IPendingOrdersService
    {
        private readonly PendingOrders.PendingOrdersClient _pendingOrdersClient;
        private readonly GrpcChannel _grpcChannel;

        public PendingOrdersService()
        {
            _grpcChannel = GrpcChannel.ForAddress("http://localhost:50001");
            _pendingOrdersClient = new PendingOrders.PendingOrdersClient(_grpcChannel);
        }

        public async Task<PendingOrderReply> RegisterPendingOrderAsync(PendingOrderRequest request)
        {
            var reply = await _pendingOrdersClient.RegisterPendingOrderAsync(request);
            Console.WriteLine($"Response from PendingOrders GRPC Service: {reply.Success}");

            return reply;
        }
    }
}