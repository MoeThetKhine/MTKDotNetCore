namespace MTKDotNetCore.Domain.Features.Blog;

public class BlogV2Service : IBlogService
{
    private readonly AppDbContext _db;
    private readonly BlogService _blogService;

    public BlogV2Service(AppDbContext db, BlogService blogService)
    {
        _db = db;
        _blogService = blogService;
    }

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

    #region PatchBlog

    public TblBlog PatchBlog(int id, TblBlog blog)
    {
        var item = _db.TblBlogs.AsNoTracking()
            .FirstOrDefault(x => x.BlogId == id);

        if (item is null)
        {
            return null;
        }

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            item.BlogTitle = blog.BlogTitle;
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            item.BlogAuthor = blog.BlogAuthor;
        }
        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            item.BlogContent = blog.BlogContent;
        }
        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
        return item;
    }

    #endregion

    #region DeleteBlog

    public bool? DeleteBlog(int id)
    {
        var item = _db.TblBlogs
            .AsNoTracking()
            .FirstOrDefault(x => x.BlogId == id);

        if (item is null)
        {
            return null;
        }
        _db.Entry(item).State = EntityState.Deleted;
        int result = _db.SaveChanges();
        return result > 0;
    }

    #endregion

}
