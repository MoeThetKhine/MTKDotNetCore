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
    }
}
