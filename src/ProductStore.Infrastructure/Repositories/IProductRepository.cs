using ProductStore.Domain.Dtos;
using ProductStore.Domain.Entities;
using ProductStore.Infrastructure.Repositories.BaseReposiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStore.Infrastructure.Repositories
{
    public interface IProductRepository:IBase<Product>
    {
    }
}
