﻿using MTKDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;

#region Day2

#region ConnectionString

//string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
//Console.WriteLine ($"Connection String : + { connectionString}");
//Console.WriteLine("Connection String :" + connectionString);

#endregion


//SqlConnection connection = new SqlConnection(connectionString);

#region ConnectionOpen

//Console.WriteLine("Connection Opening");
//connection.Open();
//Console.WriteLine("Connection Opened");

#endregion

#region query

//string query = @"SELECT [BlogId]
//      ,[BlogTitle]
//      ,[BlogAuthor]
//      ,[BlogContent]
//      ,[DeleteFlag]
//  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0;";

#endregion

#region Executing

//SqlCommand cmd = new SqlCommand(query, connection);
////SqlDataAdapter adapter = new SqlDataAdapter(cmd);
////DataTable dt = new DataTable();
////adapter.Fill(dt); (or) dt = adapter.Execute();
//SqlDataReader reader = cmd.ExecuteReader();

//while (reader.Read())
//{
//    Console.WriteLine(reader["BlogId"]);
//    Console.WriteLine(reader["BlogTitle"]);
//    Console.WriteLine(reader["BlogAuthor"]);
//    Console.WriteLine(reader["BlogContent"]);
//}

#endregion

#region ConnectionClose

//Console.WriteLine("Connection Closing");
//connection.Close();
//Console.WriteLine("Connection Closed");

#endregion

//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine(dr["BlogId"]);
//    Console.WriteLine(dr["BlogTitle"]);
//    Console.WriteLine(dr["BlogAuthor"]);
//    Console.WriteLine(dr["BlogContent"]);

//}

//Console.ReadKey();

#endregion

#region Day3

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Update();
//adoDotNetExample.Edit();
//adoDotNetExample.Delete();

#endregion

DapperExample dapperExample = new DapperExample();
dapperExample.Read();