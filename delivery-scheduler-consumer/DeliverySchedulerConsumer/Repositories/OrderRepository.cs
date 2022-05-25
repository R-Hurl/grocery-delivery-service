using System;
using System.Linq;
using System.Threading.Tasks;
using GroceryDeliveryAPI;
using Microsoft.EntityFrameworkCore;

namespace DeliverySchedulerConsumer.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DeliverySchedulerDbContext _dbContext;
        private const string ORDER_STATUS_DELIVERED = "D";

        public OrderRepository(DeliverySchedulerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SetOrderStatusToScheduledForDeliveryAsync(Guid orderId)
        {
            var orderToUpdate = await _dbContext.Orders.Where(order => order.OrderId == orderId).FirstOrDefaultAsync();

            if (orderToUpdate != null)
            {
                // Set Order Status to Delivered.
                orderToUpdate.OrderStatus = ORDER_STATUS_DELIVERED;

                _dbContext.SaveChanges();
            }
        }
    }
}