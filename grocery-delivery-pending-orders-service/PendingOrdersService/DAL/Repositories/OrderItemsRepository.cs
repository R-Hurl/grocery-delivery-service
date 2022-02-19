using PendingOrdersService.DAL.Repositories.Interfaces;

namespace PendingOrdersService.DAL.Repositories
{
    public class OrderItemsRepository : GenericRepository<Models.OrderItem>, IOrderItemsRepository
    {
        public OrderItemsRepository(PendingOrdersServiceDBContext dbContext) : base(dbContext)
        {

        }
    }
}