using ANPDB.Data;
using ANPDB.Models;
using ANPDB.Repositories.Interfaces;

namespace ANPDB.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
    
        public IGenericRepository<Product> Products { get; }
        public IGenericRepository<Category> Categories { get; }
        public IGenericRepository<Order> Orders { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;

            Products = new GenericRepository<Product>(_context);
            Categories = new GenericRepository<Category>(_context);
            Orders = new GenericRepository<Order>(_context);
            
        }



        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
            =>_context.Dispose();


    }
}
