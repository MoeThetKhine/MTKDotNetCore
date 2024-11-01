﻿using MTKDotNetCore.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCore.ConsoleApp
{
    public class AdoDotNetExampe2
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";

        private readonly AdoDotNetService _adoDotNetService;

        public AdoDotNetExampe2()
        {
            _adoDotNetService = new AdoDotNetService(_connectionString);
        }
        public void Read()
        {
            string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";
           var dt = _adoDotNetService.Query(query);
            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["BlogId"]);
                Console.WriteLine(dr["BlogTitle"]);
                Console.WriteLine(dr["BlogAuthor"]);
                Console.WriteLine(dr["BlogContent"]);
            }
        }
    }
}
