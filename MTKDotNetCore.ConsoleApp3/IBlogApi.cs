using Refit;

namespace MTKDotNetCore.ConsoleApp3
{
    public interface IBlogApi
    {
        [Get("/api/blogs")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/blogs/{id}")]
        Task<List<BlogModel>> GetBlog();

        [Get("/api/blogs")]
        Task<BlogModel> CreateBlog(BlogModel blog);
    }
}
