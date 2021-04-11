using Microsoft.AspNetCore.Mvc;

namespace DynamicDatabase.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}