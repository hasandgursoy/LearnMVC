
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

    [HttpGet]
    public IActionResult Update(int id)
    {
        // Güncellemek istediğimiz datanın id den bulup asıl update'in gerçekleşeceği sayfadaki forma gönderiyoruz çok rahat ediyoruz.
        // Bu id parametresi bize asp-route-id den geliyor index den bak.
        var product = _dbContext.Products.Find(id);
        return View(product);
    }

    [HttpPost]
    public IActionResult Update(Product product)
    {


        _dbContext.Products.Update(product);
        _dbContext.SaveChanges();

        return RedirectToAction("Index");
    }


    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {

        // 1.Yontem HttpContext
        // var name = HttpContext.Request.Form["Name"].ToString();
        // var price = double.Parse(HttpContext.Request.Form["Price"].ToString());

        // 2.Yontem 
        // Method'un parametresi olarak product'ın fieldlarını yazıyoruz. name - price vs.
        // Sonra bu fieldları diğer yöntemde ki gibi inputların name="" paramteresinden alıp mapleyip savechanges diyoruz.

        // 3. Yontem Ve En Kaliteli Yontem
        // Paramatereye class veriyoruz sonra bunun fieldlarını input tagine asp-for="" diyip burada veriyoruz.

        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();

        return RedirectToAction("Index", "Product");
    }
}