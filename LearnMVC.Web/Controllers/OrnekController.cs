using Microsoft.AspNetCore.Mvc;

namespace LearnMVC.Web.Controllers
{   

    public class Producta
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    
    }

    public class OrnekController : Controller
    {
        private readonly ILogger<OrnekController> _logger;

        public OrnekController(ILogger<OrnekController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            // Hacimli nesneleri ViewModel ile gönderiyoruz.

            var productList = new List<Producta>(){
                new Producta(){Id=1,Name = "Kalem"},
                new Producta(){Id=2,Name = "Silgi"},
                new Producta(){Id=3,Name = "Defter"},

            };

            // ViewBag ile çok hacimli datalar taşınmamalı ayrıca dinamiktir çok farklı türlerde datalar taşınabilir.
            // ViewBag ve ViewData kendi controller'ı üzerinden gelen datayı sadece kendi view'ı görebilir
            // TempData 'da ise sayfalar arası data transferi mümkündür.
            ViewBag.name = "Asp.Net Core";
            
            ViewData["age"] = 25;

            ViewData["names"] = new List<String>{"hasan","sezgin","zeynep"};



            return View(productList);
        }


        // Redirect işlemini kullanıcıdan form içinde bilgi aldık diyelim sonra başka bir sayfaya yönlendirirken kullanabiliriz.
        public IActionResult ParametreView(int id)
        {
            return RedirectToAction("JsonResultParameter", "Ornek", new { id = id });
        }

        public IActionResult JsonResultParameter(int id)
        {
            return Json(new { id = id });
        }

        // Content Dönen yapılar çok daha az kullanılıyor ihtiyaç olmuyor çünkü
        public IActionResult ContentResult()
        {
            return Content("ContentResult");
        }

        public IActionResult JsonResult()
        {
            return Json(new { Id = 1, name = "Tükenmez Kalem", price = 20 });
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}