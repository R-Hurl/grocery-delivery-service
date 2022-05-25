using System;
using System.Threading.Tasks;

namespace DeliverySchedulerConsumer.Repositories
{
    public interface IOrderRepository
    {
        Task SetOrderStatusToScheduledForDeliveryAsync(Guid orderId);
    }
}