using System.Linq.Expressions;

namespace AlabAqua.Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        // READ
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        // CREATE
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);

        // UPDATE
        Task UpdateAsync(T entity);

        // DELETE
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
    }
}
