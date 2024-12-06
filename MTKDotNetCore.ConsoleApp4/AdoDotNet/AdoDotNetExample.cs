using System.Data;
using static MTKDotNetCore.ConsoleApp4.AdoDotNet.AdoDotNetService;

namespace MTKDotNetCore.ConsoleApp4.AdoDotNet
{
    public class AdoDotNetExample
    {
        private readonly AdoDotNetService _adoDotNetService;

        public AdoDotNetExample(AdoDotNetService adoDotNetService)
        {
            _adoDotNetService = adoDotNetService;
        }

        #region Read

        public void Read()
        {
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
            var dt = _adoDotNetService.Query(query);
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }

        #endregion

        #region Edit

        public void Edit()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();

            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] WHERE BlogId = @BlogId";
            var dt = _adoDotNetService.Query(query,
                new SqlParameterModel("@BlogId", id));

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        #endregion

        #region Create

        public void Create()
        {
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            string query = @"INSERT INTO [dbo].[Tbl_Blog]
          ([BlogTitle]
          ,[BlogAuthor]
          ,[BlogContent]
          ,[DeleteFlag])
    VALUES
          (@BlogTitle
          ,@BlogAuthor
          ,@BlogContent
          ,0)";

            int result = _adoDotNetService.Execute(query,
            new SqlParameterModel("@BlogTitle", title),
            new SqlParameterModel("@BlogAuthor", author),
            new SqlParameterModel("@BlogContent", content));

            Console.WriteLine(result == 1 ? "Creating Successful." : "Creating Failed.");
        }

        #endregion
    }
}
