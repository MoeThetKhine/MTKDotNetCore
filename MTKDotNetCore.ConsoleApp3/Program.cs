// See https://aka.ms/new-console-template for more information
using MTKDotNetCore.ConsoleApp3;

Console.WriteLine("Hello, World!");

HttpClientExample client = new HttpClientExample();
//await client.ReadAsync();
//await client.EditAsync(2);
//await client.EditAsync(200);
//await client.CreateAsync("test title", "test body", 3);
//await client.UpdateAsync(1, "ddd", "ddd", 1);
await client.DeleteAsync(2);

