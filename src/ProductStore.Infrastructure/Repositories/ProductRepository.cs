using Microsoft.EntityFrameworkCore;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Data;

namespace ProductStore.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async ValueTask<Product> InsertAsync(Product repo)
        {
            var product = await _appDbContext.Products.AddAsync(repo);
            await _appDbContext.SaveChangesAsync();
            return product.Entity;
        }

        public async ValueTask<Product> DeleteAsync(Guid id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            var result = _appDbContext.Products.Remove(product);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async ValueTask<IList<Product>> SelectAllAsync()
        {
            var products = await _appDbContext.Products.ToListAsync();
            return products;
        }

        public async ValueTask<Product?> SelectByNameAsync(string name)
        {
            var result = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Name == name);
            return result;
        }

        public async ValueTask<Product> UpdateAsync(Guid id, Product repo)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            var result = _appDbContext.Products.Update(product);
            await _appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async ValueTask<Product?> SelectByIdAsync(Guid id)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(x=>x.Id==id);
            return product;
        }
    }
}
