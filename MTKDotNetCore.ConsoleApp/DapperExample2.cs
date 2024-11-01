using Dapper;
using MTKDotNetCore.ConsoleApp.Models;
using MTKDotNetCore.Shared;
using System.Data;

namespace MTKDotNetCore.ConsoleApp
{
    public class DapperExample2
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";

        private readonly DapperService _dapperService;

        public DapperExample2()
        {
            _dapperService = new DapperService(_connectionString);
        }

        #region Read

        public void Read()
        {
            string query = "select * from tbl_blog where DeleteFlag = 0;";
            var lst = _dapperService.Query<BlogDapperDataModel>(query).ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        #endregion

        #region Create

        public void Create(string title, string author, string content)
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

           int result = _dapperService.Execute(query, new BlogDapperDataModel
           {
               BlogTitle = title,
               BlogAuthor = author,
               BlogContent = content,
           });
           Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Fail.");
        }

        #endregion 

        #region Edit

        public void Edit(int id)
        {
            string query = "select * from tbl_blog where DeleteFlag = 0 and BlogId = @BlogId;";
            var item = _dapperService.QueryFirstOrDefault<BlogDapperDataModel>(query, new BlogDapperDataModel
            {
                BlogId = id,
            });

            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        #endregion

        #region Delete

        public void Delete(int id)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET [DeleteFlag] = 1  WHERE BlogId = @BlogId";
            int result = _dapperService.Execute(query, new BlogDapperDataModel
            {
                BlogId = id,
            });
            Console.WriteLine(result == 1 ? "Deleting Successful." : "Deleting Fail.");
        }

        #endregion

        #region Update

        public void Update(int id, string title, string author, string content)
        {
            string query = $@"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle
      ,[BlogAuthor] = @BlogAuthor
      ,[BlogContent] = @BlogContent
      ,[DeleteFlag] = 0
 WHERE BlogId = @BlogId;";

            int result = _dapperService.Execute(query, new BlogDapperDataModel
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            });
            Console.WriteLine(result == 1 ? "Updating Successful." : "Updating Fail.");
        }
        #endregion
    }
}
