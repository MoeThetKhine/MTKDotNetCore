using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MTKDotNetCore.RestApi.DataModels;
using MTKDotNetCore.RestApi.ViewModels;

namespace MTKDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNetController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        [HttpGet]
        public IActionResult GetBlog()
        {
            List<BlogViewModel>lst = new List<BlogViewModel>();
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);

                var item = new BlogViewModel
                {
                    BlogId = Convert.ToInt32(reader["BlogId"]),
                    BlogTitle = Convert.ToString(reader["BlogTitle"]),
                    BlogAuthor = Convert.ToString(reader["BlogAuthor"]),
                    BlogContent = Convert.ToString(reader["BlogContent"]),
                    DeleteFlag = Convert.ToBoolean(reader["DeleteFlag"]),
                };
                lst.Add(item);
            }
            connection.Close();
            return Ok(lst);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id,BlogViewModel blog)
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
            if(conditions.Length == 0)
            {
                return BadRequest("Invalid Parameters!");
            }
            conditions = conditions.Substring(0,conditions.Length-2);

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"Update [dbo].[Tbl_Blog]
SET {conditions} WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }
            int result = cmd.ExecuteNonQuery();
            return Ok(result > 0 ? "Updating Successful." : "Updating Failed.");
        }

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
          ,0)";
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle );
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            return Ok(result == 1 ? "Saving Successful" : "Saving Failed");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            string query = $@"UPDATE [dbo].[Tbl_Blog]
               SET [DeleteFlag] = 1  WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@DeleteFlag", 1);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return Ok(result == 1 ? "Deleting Successful." : "Deleting Failed.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogDataModel blog)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = $@"UPDATE [dbo].[Tbl_Blog]
  SET [BlogTitle] = @BlogTitle
     ,[BlogAuthor] = @BlogAuthor
     ,[BlogContent] = @BlogContent
     ,[DeleteFlag] = 0
WHERE BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);    
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            return Ok(result == 1 ? "Updating Successful." : "Updating Failed.");
        }

    }
}
