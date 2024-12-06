#region DI In AdoDotNetExample

#region DI

//var services = new ServiceCollection()
//            .AddSingleton<AdoDotNetService>(provider =>
//            new AdoDotNetService("Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;"))
//            .AddSingleton<AdoDotNetExample>()
//            .BuildServiceProvider();

//var adoDotNetExample = services.GetRequiredService<AdoDotNetExample>();

#endregion

//Console.WriteLine("Read");
//adoDotNetExample.Read();

//Console.WriteLine("Create");
//adoDotNetExample.Create();

//Console.WriteLine(" Edit");
//adoDotNetExample.Edit();

//Console.WriteLine("Delete");
//adoDotNetExample.Delete();

//Console.WriteLine("Update");
//adoDotNetExample.Update();

#endregion

#region DI In Dapper

#region DI

//var service1 = new ServiceCollection()
//           .AddSingleton<DapperService>(provider => new DapperService("Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;"))
//           .AddSingleton<DapperExample>()
//           .AddSingleton<DapperQueries>()
//           .BuildServiceProvider();

#endregion

//var dapperExample = service1.GetRequiredService<DapperExample>();

//dapperExample.Read();
//dapperExample.Create("New Blog", "Author", "Content");
//dapperExample.Edit(1);
//dapperExample.Update(1, "Updated Blog", "Updated Author", "Updated Content");
//dapperExample.Delete(78);

#endregion