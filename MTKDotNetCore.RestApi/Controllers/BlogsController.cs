using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.Database.Models;

namespace MTKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        #region GetBlogs

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _db.TblBlogs
                .AsNoTracking ()
                .Where(x => !x.DeleteFlag)
                .ToList ();
            return Ok (lst);
        }

        #endregion

        #region GetBlog(Edit)

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {

            var item = _db.TblBlogs
                .AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return NotFound();
            }
            return Ok (item);
        }

        #endregion

        #region CreateBlog

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            _db.TblBlogs.Add(blog);
            _db.SaveChanges();
            return Ok(blog);
        }

        #endregion

        #region Update Blog

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking()
                .FirstOrDefault(x => x.BlogId == id);
            if(item is null)
            {
                return NotFound();
            }
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }

        #endregion

        #region Patch Blog

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,TblBlog blog)
        {
            var item = _db.TblBlogs.AsNoTracking()
                .FirstOrDefault (x => x.BlogId == id);
            if(item is null)
            {
                return NotFound();
            }
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                item.BlogTitle = blog.BlogTitle;
            }
            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                item.BlogAuthor = blog.BlogAuthor;
            }
            _db.Entry (item).State = EntityState.Modified;
            _db.SaveChanges();
            return Ok(item);
        }

        #endregion

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var item = _db.TblBlogs.AsNoTracking()
                .FirstOrDefault(x=> x.BlogId == id);
            if(item is null)
            {
                return NotFound();
            }
            item.DeleteFlag = true;
            _db.Entry(item) .State = EntityState.Modified;
            _db.SaveChanges();
            return Ok();
        }
    }
}
