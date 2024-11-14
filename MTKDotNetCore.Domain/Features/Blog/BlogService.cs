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

    #region Edit Blog

    public TblBlog GetBlog(int id)
    {
        var item = _db.TblBlogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
        return item;
    }

    #endregion

    #region CreateBlog

    public TblBlog CreateBlog(TblBlog blog)
    {
        _db.TblBlogs.Add(blog);
        _db.SaveChanges();
        return blog;
    }

    #endregion

    #region UpdateBlog

    public TblBlog UpdateBlog(int id, TblBlog blog)
    {
        var item = _db.TblBlogs
            .AsNoTracking()
            .FirstOrDefault(x => x.BlogId == id);

        if (item is null)
        {
            return null;
        }
        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
        return item;
    }

    #endregion


}
