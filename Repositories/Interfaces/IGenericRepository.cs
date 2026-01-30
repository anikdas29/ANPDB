using System.Linq.Expressions;

namespace ANPDB.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        //Task<IEnumerable<T>> GetByValueAsync(string value);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task Update(T entity);
        //Task Delete(T entity);
        Task Remove(T entity);
    }
}
