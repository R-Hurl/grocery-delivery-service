using PendingOrdersService.DAL.Repositories.Interfaces;

namespace PendingOrdersService.DAL.Repositories
{
    public class OrdersRepository : GenericRepository<Models.Order>, IOrdersRepository
    {
        public OrdersRepository(PendingOrdersServiceDBContext dbContext) : base(dbContext) { }
    }
}