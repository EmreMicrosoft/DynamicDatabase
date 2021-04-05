using DynamicDatabase.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DynamicDatabase.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            //var entityType = new EntityType();
            return View();
        }
    }
}