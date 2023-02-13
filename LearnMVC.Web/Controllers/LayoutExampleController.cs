using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LearnMVC.Web.Controllers
{
    public class LayoutExampleController : Controller
    {

        // Hangi layout'u kullanmak istediğimize ilgili action'ın cshtml dosyasında yukarıda Layout = blabal diye çağırıyoruz.
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult NoLayout()
        {
            return View();
        }

    }
}