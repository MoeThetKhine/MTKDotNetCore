namespace MTKDotNetCore.Domain.Features.Blog;

public class BlogService
{
    private readonly AppDbContext _db = new AppDbContext();

    #region GetBlog

    public List<TblBlog> GetBlogs()
    {
        var model = _db.TblBlogs.AsNoTracking().ToList();
        return model;
    }

    #endregion
    
}
