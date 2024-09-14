using System.Data.SqlClient;

string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;";
//Console.WriteLine ($"Connection String : + { connectionString}");
Console.WriteLine("Connection String :" + connectionString);

SqlConnection connection = new SqlConnection(connectionString);

Console.WriteLine("Connection Opening");
connection.Open();
Console.WriteLine("Connection Opened");


Console.WriteLine("Connection Closing");
connection.Close();
Console.WriteLine("Connection Closed");