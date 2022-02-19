using System.Threading.Tasks;
using PendingOrdersService.DAL.Repositories.Interfaces;

namespace PendingOrdersService.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PendingOrdersServiceDBContext _dbContext;

        public UnitOfWork(PendingOrdersServiceDBContext dbContext)
        {
            _dbContext = dbContext;
            Orders = new OrdersRepository(_dbContext);
            OrderItems = new OrderItemsRepository(_dbContext);
        }
        public IOrdersRepository Orders { get; }

        public IOrderItemsRepository OrderItems { get; }

        public async Task<int> CompleteAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}