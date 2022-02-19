using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PendingOrdersService.DAL.Repositories.Interfaces;

namespace PendingOrdersService.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PendingOrdersServiceDBContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PendingOrdersServiceDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetByID(object id) => await _dbSet.FindAsync(id);

        public EntityEntry<TEntity> Insert(TEntity entity) => _dbSet.Add(entity);

        public void InsertRange(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        public async Task Delete(object id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            Delete(entityToDelete);
        }

        private void Delete(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }

            _dbSet.Remove(entityToDelete);
        }

        public void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}