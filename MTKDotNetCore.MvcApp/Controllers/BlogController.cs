﻿namespace MTKDotNetCore.MvcApp.Controllers;

public class BlogController : Controller
{
		private readonly IBlogService _blogService;

		public BlogController(IBlogService blogService)
		{
			_blogService = blogService;
		}

	#region Index

	//  public IActionResult Index()
	//{
	//	var lst = _blogService.GetBlogs();
	//	return View(lst);
	//}

	public IActionResult Index(int pageIndex = 1, int pageSize = 10)
	{
		var blogs = _blogService.GetBlogs().AsQueryable();

		var paginatedBlogs = PaginatedList<TblBlog>.Create(blogs, pageIndex, pageSize);

		return View(paginatedBlogs);
	}
	#endregion

	#region BlogCreate

	[ActionName("Create")]
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    #endregion

    #region BlogSave

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

    #endregion

    #region BlogDelete

    [ActionName("Delete")]
    public IActionResult BlogDelete(int id)
    {
        _blogService.DeleteBlog(id);
        return RedirectToAction("Index");
    }

    #endregion

    #region BlogEdit

    [ActionName("Edit")]
    public IActionResult BlogEdit(int id)
    {
        var blog = _blogService.GetBlog(id);
        BlogRequestModel blogRequestModel = new BlogRequestModel
        {
            Id = (int)blog.BlogId,
            Author = blog.BlogAuthor,
            Content = blog.BlogContent,
            Title = blog.BlogTitle
        };
        return View("BlogEdit", blogRequestModel);
    }

    #endregion

    #region BlogUpdate

    [HttpPost]
    [ActionName("Update")]
    public IActionResult BlogUpdate(int id, BlogRequestModel requestModel)
    {
        try
        {
            _blogService.UpdateBlog(id, new TblBlog
            {
                BlogAuthor = requestModel.Author,
                BlogContent = requestModel.Content,
                BlogTitle = requestModel.Title
            });

            TempData["IsSuccess"] = true;
            TempData["Message"] = "Blog Updated Successfully";
        }
        catch (Exception ex)
        {
            TempData["IsSuccess"] = false;
            TempData["Message"] = ex.ToString();
        }

        return RedirectToAction("Index");
    }

    #endregion

}
