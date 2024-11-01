using MTKDotNetCore.ConsoleApp.Models;
using MTKDotNetCore.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
