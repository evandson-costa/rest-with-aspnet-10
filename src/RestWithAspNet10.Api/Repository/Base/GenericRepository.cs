using Microsoft.EntityFrameworkCore;
using RestWithAspNet10.Api.Interface.Base;
using RestWithAspNet10.Api.Model.Base;
using RestWithAspNet10.Model;


namespace   RestWithAspNet10.Api.Repository.Base
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {

        private readonly MSSQLContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public Task<T> CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
            return Task.FromResult(entity);
        }

        public Task DeleteAsync(long id)
        {
            var entity = _dbSet.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with id {id} not found.");
            }
            _dbSet.Remove(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<bool> ExistsAsync(long id)
        {
            return Task.FromResult(_dbSet.Any(e => e.Id == id));
        }     

        public Task UpdateAsync(T entity)
        {
            var existingEntity = _dbSet.Find(entity.Id);
            if (existingEntity == null)
            {
                throw new KeyNotFoundException($"Entity with id {entity.Id} not found.");
            }
            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        Task<IEnumerable<T>> IGenericRepository<T>.GetAllAsync()
        {
            return Task.FromResult(_dbSet.AsEnumerable());
        }

        Task<T> IGenericRepository<T>.GetByIdAsync(long id)
        {
            return Task.FromResult(_dbSet.Find(id));
        }
    }
}