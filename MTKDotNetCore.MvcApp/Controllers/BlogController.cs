using Microsoft.AspNetCore.Mvc;

namespace MTKDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
