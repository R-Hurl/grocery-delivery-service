using System;
using System.Threading.Tasks;

namespace PendingOrdersService.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrdersRepository Orders { get; }
        IOrderItemsRepository OrderItems { get; }
        Task<int> CompleteAsync();
    }
}