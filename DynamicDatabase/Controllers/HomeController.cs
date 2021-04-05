using DynamicDatabase.Data.Repos.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace DynamicDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAttributeRepository _repos;
        public HomeController(IAttributeRepository repos)
        {
            _repos = repos;
        }

        public IActionResult Index()
        {
            return View(_repos.GetListAsync().Result);
        }
    }
}