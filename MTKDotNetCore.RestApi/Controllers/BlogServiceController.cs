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
    }
}
