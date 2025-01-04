namespace MTKDotNetCore.MvcApp.Controllers;

public class BlogController : Controller
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    #region Index

    public IActionResult Index()
    {
        var lst = _blogService.GetBlogs();
        return View();
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

            TempData["IsSuccess"] = true;
            TempData["Message"] = "Blog Created Successfully";
        }
        catch (Exception ex)
        {

            TempData["IsSuccess"] = false;
            TempData["Message"] = ex.ToString();
        }

        return RedirectToAction("Index");
    }

    #endregion

    [ActionName("Delete")]
    public IActionResult BlogDelete(int id)
    {
        _blogService.DelteBlog(id);
        return RedirectToAction("Index");
    }

    [ActionName("Edit")]
    public IActionResult BlogEdit(int id)
    {
        var blog = _blogService.GetBlog(id);
        BlogRequestModel blogRequestModel = new BlogRequestModel
        {
            Id = blog.BlogId,
            Author = blog.BlogAuthor,
            Content = blog.BlogContent,
            Title = blog.BlogTitle
        };
        return View("BlogEdit", blogRequestModel);
    }

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
}


