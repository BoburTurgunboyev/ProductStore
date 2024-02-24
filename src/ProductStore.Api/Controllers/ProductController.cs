using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Services;
using ProductStore.Domain.Dtos;
using ProductStore.Domain.Entities;

namespace ProductStore.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll()
        {
            var products = await _productService.RetrieveAllAsync();
            return Ok(products);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetByName(string name)
        {
            var product = await _productService.RetrieveByNameAsync(name);
            return Ok(product);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Post(ProductDto productDto)
        {
            var product = await _productService.AddAsync(productDto);
            return Ok(product);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Put(Guid id, Product productDto)
        {
            var product = await _productService.ModifyAsync(id, productDto);
            return Ok(product);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> Delete(Guid id) 
        {
            var product = await _productService.RemoveAsync(id);
            return Ok(product);
        }


    }
}
