using ProductStore.Domain.Dtos;
using ProductStore.Domain.Entities;

namespace ProductStore.Application.Services
{
    public interface IProductService
    {
        public ValueTask<Product> AddAsync(ProductDto productDto);

        public ValueTask<Product> ModifyAsync(Guid id, ProductDto productDto);

        public ValueTask<Product> RemoveAsync(Guid id);

        public ValueTask<Product?> RetrieveByNameAsync(string name);

        public ValueTask<IList<Product>> RetrieveAllAsync();
    }
}
