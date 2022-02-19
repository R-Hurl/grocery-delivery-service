using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PendingOrdersService.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByID(object id);
        EntityEntry<TEntity> Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        Task Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}