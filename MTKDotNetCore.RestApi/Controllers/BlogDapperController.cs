namespace MTKDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogDapperController : ControllerBase
{
    private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

    #region GetBlog

    [HttpGet]
    public IActionResult GetBlog()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            string query = "select * from tbl_blog where DeleteFlag = 0;";
            List<BlogDataModel> lst = db.Query<BlogDataModel>(query).ToList();
            return Ok(lst);
        }
    }

    #endregion

    #region EditBlog

    [HttpGet("{id}")]
    public IActionResult Edit(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            string query = "select * from tbl_blog where DeleteFlag = 0 and BlogId = @BlogId;";
            var item = db.Query<BlogDataModel>(query, new BlogDataModel
            {
                BlogId = id,
            }).FirstOrDefault();

           if(item is null)
            {
                return NotFound("No data found");
            }
            return Ok(item);
        }
    }

    #endregion

    #region CreateBlog

    [HttpPost]
    public IActionResult CreateBlog(BlogDataModel blog)
    {
        string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent]
           ,[DeleteFlag])
     VALUES
           (@BlogTitle
           ,@BlogAuthor
           ,@BlogContent
           ,0);";

        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            int result = db.Execute(query, blog);

            return Ok(result == 1 ? "Saving Successful" : "Saving Failed");
        }
    }

    #endregion

    #region DeleteBlog

    [HttpDelete("{id}")]
    public IActionResult DeleteBlog(int id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
               SET [DeleteFlag] = 1  WHERE BlogId = @BlogId";
            int result = db.Execute(query, new BlogDataModel
            {
                BlogId = id,
            });
            return Ok(result == 1 ? "Deleting Successful." : "Deleting Failed.");
        }
    }

    #endregion

    #region UpdateBlog

    [HttpPut("{id}")]
    public IActionResult UpdateBlog(int id, BlogDataModel blog)
    {
        string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId;";

        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            int result = db.Execute(query, blog);
            return Ok(result == 1 ? "Updating Successful." : "Updating Failed.");
        }
    }

    #endregion

    #region PatchBlog

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(int id, BlogViewModel blog)
    {
        string conditions = "";
        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            conditions += "[BlogTitle] = @BlogTitle, ";
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            conditions += "[BlogAuthor] = @BlogAuthor, ";
        }
        if (!string.IsNullOrEmpty(blog.BlogAuthor))
        {
            conditions += "[BlogAuthor] = @BlogAuthor, ";
        }
        if (conditions.Length == 0)
        {
            return BadRequest("Invalid Parameters!");
        }
        conditions = conditions.Substring(0, conditions.Length - 2);

        blog.BlogId = id;

        string query = $@"Update [dbo].[Tbl_Blog]
SET {conditions} WHERE BlogId = @BlogId";

        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            int result = db.Execute(query, blog);
            return Ok(result == 1 ? "Updating Successful." : "Updating Failed.");
        }
    }

    #endregion
}
