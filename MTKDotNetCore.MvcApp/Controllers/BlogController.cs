using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.MvcApp.Models;

namespace MTKDotNetCore.MvcApp.Controllers
{
    public class BlogController : Controller
    {
		private readonly IBlogService _blogService;

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}

		public IActionResult Index()
		{
			var lst = _blogService.GetBlogs();
			return View(lst);
		}

		
	}
}
