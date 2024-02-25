
using Microsoft.AspNetCore.Mvc;
using ProductStore.Application.Services;
using ProductStore.Domain.Dtos;
using ProductStore.Domain.Entities;
using ProductStore.MVC.Models;

namespace ProductStore.MVC.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async ValueTask<IActionResult> Index(int pg = 1)
    {
        var tasks = await _productService.RetrieveAllAsync();
        const int pageSize = 5;
        if (pg < 1)
        {
            pg = 1;
        }

        int recsCount = tasks.Count();
        var pager = new Pager(recsCount, pg, pageSize);
        int recSkip = (pg - 1) * pageSize;
        var data = tasks.Skip(recSkip).Take(pager.PageSize).ToList();
        this.ViewBag.Pager = pager;

        return View(data);
    }



    // Get: Product/Details
    public async ValueTask<IActionResult> Details(Guid id)

    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _productService.RetrieveByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }


    // Get: Product/Create
    public IActionResult Create()
    {
        return View();
    }


    // Post: Product/Create
    [HttpPost]
    [ValidateAntiForgeryToken]

    public async ValueTask<IActionResult> Create([Bind("Id,Name,Description")] ProductDto product)
    {
        if (ModelState.IsValid)
        {

            await _productService.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }


    // Get: Product/Edit
    public async ValueTask<IActionResult> Edit(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _productService.RetrieveByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // Post: Product/Edit/

    [HttpPost]
    [ValidateAntiForgeryToken]

    public async ValueTask<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var newProduct = await _productService.ModifyAsync(id, product);
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }



    //   Get:  Product/Delete
    public async ValueTask<IActionResult> Delete(Guid id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _productService.RetrieveByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // Post: Product/Delete
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async ValueTask<IActionResult> DeleteConfirmed(Guid id)
    {
        var user = await _productService.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
