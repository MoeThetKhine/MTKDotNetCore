using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
    }
}
