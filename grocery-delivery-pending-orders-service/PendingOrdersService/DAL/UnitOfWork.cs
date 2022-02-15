using System;

namespace PendingOrdersService.DAL
{
    public class UnitOfWork
    {
        private readonly PendingOrdersServiceDBContext _dbContext;

        public UnitOfWork(PendingOrdersServiceDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}