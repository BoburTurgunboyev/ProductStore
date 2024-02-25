using ProductStore.Domain.Dtos;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Repositories;

namespace ProductStore.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public async ValueTask<Product> AddAsync(ProductDto productDto)
    {
        if (productDto == null) throw new ArgumentException("The 'productDto' parameters cannot be null.");

        try
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Description = productDto.Description,
            };
            await _repository.InsertAsync(product);
            return product;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(" Product Could not created ", ex);
        }

    }

    public async ValueTask<Product> RemoveAsync(Guid id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id), "The 'id' parameter cannot be null.");

        try
        {
            var product = await _repository.DeleteAsync(id);
            return product;
        }
        catch
        {
            throw new ApplicationException($"Could not delete {id}");
        }
    }

    public async ValueTask<IList<Product>> RetrieveAllAsync()
    {
        try
        {
            var product = await _repository.SelectAllAsync();
            return product;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error retrieving products", ex);
        }
    }

    public async ValueTask<Product?> RetrieveByNameAsync(string name)
    {
        if (name is null) throw new ArgumentNullException(nameof(name), "The 'name' parameter cannot be null.");
        try
        {
            var product = await _repository.SelectByNameAsync(name);
            return product;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error retrievbyNameing products", ex);
        }
    }

    public async ValueTask<Product?> RetrieveByIdAsync(Guid id)
    {
        if (id == null) throw new ArgumentNullException(nameof(id), "The 'id' parameter cannot be null.");
        try
        {
            var product = await _repository.SelectByIdAsync(id);
            return product;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error retrievbyIDing products", ex);
        }
    }

    public async ValueTask<Product> ModifyAsync(Guid id, Product productDto)
    {
        if (productDto == null || id == null) throw new ArgumentException("Both 'productDto' and 'id' parameters cannot be null.");
        try
        {
            var product = await _repository.SelectByIdAsync(id);
            product.Name = productDto.Name;
            product.Description = productDto.Description;

            var result = await _repository.UpdateAsync(id, product);
            return result;
        }
        catch (Exception ex)
        {
            throw new ApplicationException(" Product Could not created ", ex);
        }
    }
}
