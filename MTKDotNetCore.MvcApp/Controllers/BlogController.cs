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

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }



        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogRequestModel requestModel)
        {
            try
            {
                _blogService.CreateBlog(new TblBlog
                {
                    BlogAuthor = requestModel.Author,
                    BlogContent = requestModel.Content,
                    BlogTitle = requestModel.Title
                });

                //ViewBag.IsSuccess = true;
                //ViewBag.Message = "Blog Created Successfully";

                TempData["IsSuccess"] = true;
                TempData["Message"] = "Blog Created Successfully";
            }
            catch (Exception ex)
            {
                //ViewBag.IsSuccess = false;
                //ViewBag.Message = ex.ToString();

                TempData["IsSuccess"] = false;
                TempData["Message"] = ex.ToString();
            }

            return RedirectToAction("Index");

            //var lst = _blogService.GetBlogs();
            //return View("Index", lst);
        }


    }
}
