﻿using MTKDotNetCore.ConsoleApp.Models;
using MTKDotNetCore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
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


    }
}
