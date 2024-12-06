#region DI In AdoDotNetExample

#region DI

using MTKDotNetCore.ConsoleApp4.Dapper;

var services = new ServiceCollection()
            .AddSingleton<AdoDotNetService>(provider =>
            new AdoDotNetService("Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;"))
            .AddSingleton<AdoDotNetExample>()
            .BuildServiceProvider();

var adoDotNetExample = services.GetRequiredService<AdoDotNetExample>();

#endregion

Console.WriteLine("Read");
adoDotNetExample.Read();

Console.WriteLine("Create");
adoDotNetExample.Create();

Console.WriteLine(" Edit");
adoDotNetExample.Edit();

Console.WriteLine("Delete");
adoDotNetExample.Delete();

Console.WriteLine("Update");
adoDotNetExample.Update();

#endregion

#region DI In Dapper

var service1 = new ServiceCollection()
           .AddSingleton<DapperService>(provider => new DapperService("Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;"))
           .AddSingleton<DapperExample>()
           .AddSingleton<DapperQueries>()
           .BuildServiceProvider();

var dapperExample = services.GetRequiredService<DapperExample>();

dapperExample.Read();
dapperExample.Create("New Blog", "Author", "Content");
dapperExample.Edit(1);
dapperExample.Delete(1);
dapperExample.Update(1, "Updated Blog", "Updated Author", "Updated Content");

#endregion