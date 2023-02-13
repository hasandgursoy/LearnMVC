
using LearnMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearnMVC.Web.Controllers;

public class ProductController : Controller
{
    private AppDbContext _dbContext;



    public ProductController(AppDbContext dbContext)
    {


        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        var products = _dbContext.Products.ToList();
        return View(products);
    }

    public IActionResult Remove(int id)
    {
        var product = _dbContext.Products.Find(id);
        _dbContext.Products.Remove(product ?? new Product());
        _dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Update()
    {
        return View();
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddProduct()
    {

        // 1.Yöntem HttpContext

        var name = HttpContext.Request.Form["Name"].ToString();
        var price = double.Parse(HttpContext.Request.Form["Price"].ToString());

        Product product = new()
        {
            Name = name,
            Price = price
        };

        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();

        return RedirectToAction("Index", "Product");
    }
}