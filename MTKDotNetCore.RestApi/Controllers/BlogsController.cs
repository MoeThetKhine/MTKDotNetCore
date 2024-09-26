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

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _db.TblBlogs
                .AsNoTracking ()
                .Where(x => !x.DeleteFlag)
                .ToList ();
            return Ok (lst);
        }

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
    }
}
