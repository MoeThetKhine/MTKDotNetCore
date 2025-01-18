﻿namespace MTKDotNetCore.MvcApp.Controllers;

public class BlogAjaxController : Controller
{
	private readonly IBlogService _blogService;

public BlogAjaxController(IBlogService blogService)
{
	_blogService = blogService;
}

	#region BlogList

	[ActionName("Index")]
public IActionResult BlogList()
{
	var lst = _blogService.GetBlogs();
	return View("BlogList", lst);
}

	#endregion

	#region BlogListAjax

	[ActionName("List")]
public IActionResult BlogListAjax()
{
	var lst = _blogService.GetBlogs();
	return Json(lst);
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
	MessageModel model;
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

		model = new MessageModel(true, "Blog Created Successfully");
	}
	catch (Exception ex)
	{
		TempData["IsSuccess"] = false;
		TempData["Message"] = ex.ToString();

		model = new MessageModel(false, ex.ToString());
	}

	return Json(model);
}

	#endregion

	#region MessageModel

	public class MessageModel
{
	public MessageModel()
	{
	}
	public MessageModel(bool isSuccess, string message)
	{
		IsSuccess = isSuccess;
		Message = message;
	}

	public bool IsSuccess { get; set; }
	public string Message { get; set; }
}

	#endregion

	#region BlogDelete

	[HttpPost]
[ActionName("Delete")]
public IActionResult BlogDelete(BlogRequestModel requestModel)
{
	MessageModel model;
	try
	{
		_blogService.DeleteBlog(requestModel.Id);
		model = new MessageModel(true, "Blog Deleted Successfully");
	}
	catch (Exception ex)
	{
		TempData["IsSuccess"] = false;
		TempData["Message"] = ex.ToString();

		model = new MessageModel(false, ex.ToString());
	}

	return Json(model);
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
		MessageModel model;
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

			model = new MessageModel(true, "Blog Updated Successfully");
		}
		catch (Exception ex)
		{
			TempData["IsSuccess"] = false;
			TempData["Message"] = ex.ToString();

			model = new MessageModel(false, ex.ToString());
		}
		return Json(model);

	}
		#endregion
	
}