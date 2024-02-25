using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Repositories.BaseReposiory;

namespace ProductStore.Infrastructure.Repositories;

public interface IProductRepository : IBase<Product>
{
}
