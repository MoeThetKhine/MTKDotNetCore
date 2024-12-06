#region DI In AdoDotNetExample

var services = new ServiceCollection()
            .AddSingleton<AdoDotNetService>(provider =>
            new AdoDotNetService("Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=sasa@123;"))
            .AddSingleton<AdoDotNetExample>()
            .BuildServiceProvider();

var adoDotNetExample = services.GetRequiredService<AdoDotNetExample>();

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