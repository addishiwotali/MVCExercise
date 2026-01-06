using Microsoft.AspNetCore.Mvc;
using MVCExercise.Data;

namespace MVCExercise.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

// GET
    public IActionResult Index()
    {
        var products = _repository.GetAllProducts();
        return View(products);
    }

    public IActionResult ViewProduct(int id)
    {
        var product = _repository.GetProductById(id);
        return View(product);
    }
}