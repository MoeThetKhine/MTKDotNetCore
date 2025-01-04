using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MvcApp.Models;
using System.Diagnostics;

namespace MTKDotNetCore.MvcApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Message = "Hello from Viewbag";
            ViewData["Message2"] = "Hello from ViewData";

            HomeResponseModel model = new HomeResponseModel();
            model.AlertMessage = "Hello from Model";

            //return Redirect("/Home/Privacy");

            return View(model);
        }

        
    }
}
