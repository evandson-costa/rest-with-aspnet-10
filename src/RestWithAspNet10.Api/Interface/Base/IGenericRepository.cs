using RestWithAspNet10.Api.Model.Base;

namespace RestWithAspNet10.Api.Interface.Base
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(long id);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
        Task<bool> ExistsAsync(long id);
    }
}