using Microsoft.AspNetCore.Mvc;

namespace MTKDotNetCore.MvcApp.Controllers
{
    public class AjaxBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
