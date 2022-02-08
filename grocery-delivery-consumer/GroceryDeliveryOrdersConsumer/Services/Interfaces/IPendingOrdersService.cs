using System.Threading.Tasks;

namespace GroceryDeliveryOrdersConsumer.Services.Interfaces
{
    public interface IPendingOrdersService
    {
        Task<PendingOrderReply> RegisterPendingOrderAsync(PendingOrderRequest request);
    }

}