using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryDeliveryAPI.DTOs;

namespace GroceryDeliveryAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetOrdersAsync();
        Task<List<OrderItemDTO>> GetOrderItemsAsync(string orderId);
    }
}