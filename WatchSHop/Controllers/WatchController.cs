using Microsoft.AspNetCore.Mvc;
using WatchShop.Models;
using WatchShop.MVC.Views.Watch;

namespace WatchShop.Controllers
{
    public class WatchController : Controller
    {
        private readonly DataService service;

        public WatchController(DataService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(service.GetAllWatches());

        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View(service.GetCreateVM());
        }

        [HttpPost("Create")]
        public IActionResult Create(CreateVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            service.AddWatch(viewModel);
            return RedirectToAction(nameof(Index));
        }

    }
}
