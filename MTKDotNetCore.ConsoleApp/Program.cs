using MTKDotNetCore.ConsoleApp;

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

#region Day3 AdoDotNet

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create();
//adoDotNetExample.Update();
//adoDotNetExample.Edit();
//adoDotNetExample.Delete();

#endregion

#region Day4 Dapper and EFCore

#region Dapper

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("title1","author1","content1");
//dapperExample.Edit(20);
//dapperExample.Edit(16);
//dapperExample.Update(16, "a", "b", "c");
//dapperExample.Update(20, "a", "b", "c");
//dapperExample.Delete(16);
//dapperExample.Delete(30);


#endregion

#region EFCore

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("title2", "author2", "content2");
//eFCoreExample.Edit(20);
//eFCoreExample.Edit(16);
//eFCoreExample.Update(16,"title2", "author2", "content2");
//eFCoreExample.HardDelete(12);
//eFCoreExample.SoftDelete(1);

#endregion

#endregion

#region AdoDotNetExample2

AdoDotNetExampe2 adoDotNetExampe2 = new AdoDotNetExampe2();
adoDotNetExampe2.Read();
#endregion

Console.ReadKey();