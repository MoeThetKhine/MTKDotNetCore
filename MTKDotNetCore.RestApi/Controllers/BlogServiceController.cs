using MTKDotNetCore.Domain.Features.Blog;

namespace MTKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogServiceController : ControllerBase
    {
        private readonly BlogService _service;

        public BlogServiceController()
        {
            _service = new BlogService();
        }

        #region GetBlogs

        [HttpGet]
        public IActionResult GetBlogs()
        {
            var lst = _service.GetBlogs();
            return Ok(lst);
        }

        #endregion

        #region Edit Blog

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var item = _service.GetBlog(id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        #endregion

        #region Create Blog

        [HttpPost]
        public IActionResult CreateBlog(TblBlog blog)
        {
            var model = _service.CreateBlog(blog);
            return Ok(model);
        }

        #endregion

        #region UpdateBlog

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, TblBlog blog)
        {
            var item = _service.UpdateBlog(id, blog);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        #endregion

        #region Patch Blog

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, TblBlog blog)
        {
            var item = _service.PatchBlog(id, blog);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        #endregion


    }
}
