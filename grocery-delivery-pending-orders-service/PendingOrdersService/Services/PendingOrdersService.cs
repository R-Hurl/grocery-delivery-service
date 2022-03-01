using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using PendingOrdersService.DAL.Repositories.Interfaces;
using PendingOrdersService.Models;

namespace PendingOrdersService.Services
{
    class PendingOrdersService : PendingOrders.PendingOrdersBase
    {
        private readonly ILogger<PendingOrdersService> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public PendingOrdersService(IUnitOfWork unitOfWork, ILogger<PendingOrdersService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public override Task<PendingOrderReply> RegisterPendingOrder(PendingOrderRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Successfully called GRPC PendingOrdersService with the following request: {JsonSerializer.Serialize(request)}");
            var pendingOrderReply = new PendingOrderReply { Success = false };

            try
            {
                var order = new Models.Order
                {
                    OrderId = Guid.Parse(request.OrderNumber),
                    CustomerId = 1, // Fix this later once registering and login is working
                    OrderStatus = OrderStatus.Pending,
                    Total = (decimal)request.Order.Total
                };
                _unitOfWork.Orders.Insert(order);

                var orderItems = new List<Models.OrderItem>();
                foreach (var cartItem in request.Order.Cart)
                {
                    orderItems.Add(new OrderItem
                    {
                        ProductId = cartItem.Product.Id,
                        Quantity = cartItem.Quantity,
                        OrderId = Guid.Parse(request.OrderNumber)
                    });
                }
                _unitOfWork.OrderItems.InsertRange(orderItems);

                _unitOfWork.CompleteAsync();

                pendingOrderReply.Success = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(1000, "RegisterPendingOrderException"), ex, "Exception Occurred Attempting to Register Pending Grocery Deliver Order", request);
            }

            return Task.FromResult<PendingOrderReply>(pendingOrderReply);
        }
    }
}