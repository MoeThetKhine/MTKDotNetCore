using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MTKDotNetCore.ToDoListRestApi.DataModels;
using MTKDotNetCore.ToDoListRestApi.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.ToDoListRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        #region GetCategory

        [HttpGet]
        public IActionResult GetCategory()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"SELECT [CategoryID]
      ,[CategoryName]
      ,[IsDelete]
  FROM [dbo].[TaskCategory] where IsDelete = 0;";
            List<CategoryDataModel> lst = db.Query<CategoryDataModel>(query).ToList();
            return Ok(lst);
        }

        #endregion

        #region CreateCategory

        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel category)
        {
            string query = $@"INSERT INTO [dbo].[TaskCategory]
           ([CategoryName]
           ,[IsDelete])
     VALUES
           (@CategoryName
           ,0);";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, category);

                return Ok(result == 1 ? "Saving Successful" : "Saving Failed");
            }
        }

        #endregion

        #region UpdateCategory

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, CategoryViewModel category)
        {
           var item = FindById(id);

            if(item is null)
            {
                return NotFound("No Data Found");
            }
            string query = @"UPDATE [dbo].[TaskCategory]
                               SET [CategoryName] = @CategoryName
                               WHERE IsDelete = 0;";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, category);
                return Ok(result == 1 ? "Updating Successful." : "Updating Failed.");
            }
        
        }

        #endregion

        #region SoftDeleteCategory

        [HttpDelete("{id}")]
        public IActionResult SoftDeleteCategory(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var item = FindById(id);
                if (item is null)
                {
                    return NotFound("No Data Found");
                }

                string query = $@"UPDATE [dbo].[TaskCategory]
               SET [IsDelete] = 1  WHERE CategoryID = @CategoryID";
                int result = db.Execute(query, new CategoryDataModel
                {
                    CategoryId = id,
                });
                return Ok(result == 1 ? "Deleting Successful." : "Deleting Failed.");
            }
        }

        #endregion

        #region FindById

        private CategoryDataModel? FindById(int id)
        {
            string query = @"SELECT [CategoryID]
                          ,[CategoryName]
                          ,[IsDelete]
                     FROM [dbo].[TaskCategory] 
                     WHERE CategoryID = @CategoryID AND IsDelete = 0;";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = db.Query<CategoryDataModel>(query, new { CategoryID = id }).FirstOrDefault();
                return result;
            }
        }

        #endregion

    }
}
