using Dapper;
using Microsoft.AspNetCore.Mvc;
using MTKDotNetCore.ToDoListRestApi.DataModels;
using MTKDotNetCore.ToDoListRestApi.ViewModels;
using System.Data;
using System.Data.SqlClient;

namespace MTKDotNetCore.ToDoListRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";

        #region GetToDoList

        [HttpGet]
        public IActionResult GetToDoList()
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"SELECT [TaskID]
      ,[TaskTitle]
      ,[TaskDescription]
      ,[CategoryID]
      ,[PriorityLevel]
      ,[Status]
      ,[DueDate]
      ,[CreatedDate]
      ,[CompletedDate]
  FROM [dbo].[ToDoList]";
            List<ToDoListDataModel> lst = db.Query<ToDoListDataModel>(query).ToList();
            return Ok(lst);
        }

        #endregion

        #region  GetToDoList By CreatedDate

        [HttpGet("{createdDate}")]
        public IActionResult GetToDoList(DateTime createdDate)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            string query = @"SELECT [TaskID]
                          ,[TaskTitle]
                          ,[TaskDescription]
                          ,[CategoryID]
                          ,[PriorityLevel]
                          ,[Status]
                          ,[DueDate]
                          ,[CreatedDate]
                          ,[CompletedDate]
                     FROM [dbo].[ToDoList]
                     WHERE CAST(CreatedDate AS DATE) = @CreatedDate";

            var lst = db.Query<ToDoListDataModel>(query, new { CreatedDate = createdDate.Date }).ToList();
            return Ok(lst);
        }

        #endregion

        #region CreateToDoList

        [HttpPost]
        public IActionResult CreateToDoList(ToDoListViewModel viewModel)
        {
            var category = FindByCategoryId(viewModel.CategoryId ?? 0);

            if (category is null)
            {
                return BadRequest("Category does not exist.");
            }

            string query = @"INSERT INTO [dbo].[ToDoList]
           ([TaskTitle]
           ,[TaskDescription]
           ,[CategoryID]
           ,[PriorityLevel]
           ,[Status]
           ,[DueDate]
           ,[CompletedDate])
     VALUES
           (@TaskTitle
           ,@TaskDescription
           ,@CategoryID
           ,@PriorityLevel
           ,@Status
           ,@DueDate
           ,@CompletedDate)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, viewModel);
                return Ok(result == 1 ? "Creating Successful." : "Creating Fail.");
            }
        }

        #endregion

        #region UpdateToDoList

        [HttpPut("{id}")]
        public IActionResult UpdateToDoList(int id, ToDoListViewModel viewModel)
        {
            var item = FindById(id);

            if (item is null)
            {
                return NotFound("No Data Found");
            }
            string query = @"UPDATE [dbo].[ToDoList]
                       SET [TaskTitle] = @TaskTitle
                          ,[TaskDescription] = @TaskDescription
                          ,[CategoryID] = @CategoryID
                          ,[PriorityLevel] = @PriorityLevel
                          ,[Status] = @Status
                          ,[DueDate] = @DueDate
                          ,[CompletedDate] = @CompletedDate;";
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, viewModel);
                return Ok(result == 1 ? "Updating Successful." : "Updating Failed.");
            }

        }

        #endregion

        #region DeleteToDoList

        [HttpDelete("{id}")]
        public IActionResult DeleteToDoList(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var item = FindById(id);
                if (item is null)
                {
                    return NotFound("No Data Found");
                }

                string query = $@"DELETE FROM [dbo].[ToDoList]
      WHERE TaskID = @TaskID";
                int result = db.Execute(query, new ToDoListDataModel
                {
                    TaskID = id,
                });
                return Ok(result == 1 ? "Deleting Successful." : "Deleting Failed.");
            }
        }

        #endregion

        #region PatchToDoList

        [HttpPatch("{id}")]
        public IActionResult PatchToDoList(int id, ToDoListDataModel viewModel)
        {
            if (viewModel.PriorityLevel.HasValue && 
              (viewModel.PriorityLevel < 1 || viewModel.PriorityLevel > 5))
            {
                return BadRequest("PriorityLevel must be between 1 and 5.");
            }

            string conditions = "";

            if (!string.IsNullOrEmpty(viewModel.TaskTitle))
            {
                conditions += "[TaskTitle] = @TaskTitle, ";
            }
            if (!string.IsNullOrEmpty(viewModel.TaskDescription))
            {
                conditions += "[TaskDescription] = @TaskDescription, ";
            }
            if (viewModel.CategoryId.HasValue)
            {
                conditions += "[CategoryID] = @CategoryID, ";
            }
            if (viewModel.PriorityLevel.HasValue)
            {
                conditions += "[PriorityLevel] = @PriorityLevel, ";
            }
            if (!string.IsNullOrEmpty(viewModel.Status))
            {
                conditions += "[Status] = @Status, ";
            }
            if (viewModel.DueDate.HasValue)
            {
                conditions += "[DueDate] = @DueDate, ";
            }
            if (viewModel.CompletedDate.HasValue)
            {
                conditions += "[CompletedDate] = @CompletedDate, ";
            }

            if (conditions.Length == 0)
            {
                return BadRequest("No fields to update.");
            }

            conditions = conditions.Substring(0, conditions.Length - 2);

            viewModel.TaskID = id;

            string query = $@"UPDATE [dbo].[ToDoList]
              SET {conditions} 
              WHERE TaskID = @TaskID";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, viewModel);
                if (result == 0)
                {
                    return NotFound("No task found with the given TaskID.");
                }
                return Ok("Updating Successful.");
            }
        }

        #endregion

        #region FindById

        private ToDoListDataModel? FindById(int id)
        {
            string query = @"SELECT [TaskID]
      ,[TaskTitle]
      ,[TaskDescription]
      ,[CategoryID]
      ,[PriorityLevel]
      ,[Status]
      ,[DueDate]
      ,[CreatedDate]
      ,[CompletedDate]
  FROM[dbo].[ToDoList]
        WHERE TaskID = @TaskID";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = db.Query<ToDoListDataModel>(query, new { TaskID = id }).FirstOrDefault();
                return result;
            }
        }

        #endregion

        #region FindByCategoryId

        private CategoryDataModel? FindByCategoryId(int id)
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
