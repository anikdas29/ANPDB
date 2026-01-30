using ANPDB.Models;

namespace ANPDB.Repositories.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Order> Orders { get; }

        Task<int> SaveAsync();
    }
}
