using DynamicDatabase.Data.Repos.Abstract;
using DynamicDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace DynamicDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntityTypeRepository _repos;
        public HomeController(IEntityTypeRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var model = new HomeViewModel
            //{
            //    EntityTypes = _repos.GetListAsync().Result
            //};

            //return View(model);
            
            return View();
        }
    }
}