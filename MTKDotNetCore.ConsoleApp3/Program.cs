// See https://aka.ms/new-console-template for more information
using MTKDotNetCore.ConsoleApp3;

Console.WriteLine("Hello, World!");

HttpClientExample client = new HttpClientExample();
await client.ReadAsync();
