namespace MTKDotNetCore.ConsoleApp3;

public interface IBlogApi
{
    [Get("/api/blogs")]
    Task<List<BlogModel>> GetBlogs();

    [Get("/api/blogs/{id}")]
    Task<List<BlogModel>> GetBlog();

    [Get("/api/blogs")]
    Task<BlogModel> CreateBlog(BlogModel blog);
}

#region BlogModel

public class BlogModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
    public bool DeleteFlag {  get; set; }
}

#endregion
