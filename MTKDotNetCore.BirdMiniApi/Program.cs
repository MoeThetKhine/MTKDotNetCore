using MTKDotNetCore.BirdMiniApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region GetBirds

app.MapGet("/birds", () =>
{

    string folderPath = "Data/Bird.json";
    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr)!;
    return Results.Ok(result.Tbl_Bird);

}).WithName("GetBirds")
.WithOpenApi();

#endregion

app.Run();
