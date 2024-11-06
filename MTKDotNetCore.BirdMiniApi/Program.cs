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

#region Edit Birds

app.MapGet("/birds/{id}", (int id) =>
{
    string folderPath = "Data/Bird.json";

    var jsonStr = File.ReadAllText(folderPath);
    var result = JsonConvert.DeserializeObject<BirdResponseModel>(jsonStr)!;

    var item = result.Tbl_Bird.FirstOrDefault(x=> x.Id == id);

    if(item is null)
    {
        return Results.BadRequest("No Data Found");
    }
    return Results.Ok(item);
}).WithName("EditBird")
.WithOpenApi();

#endregion

app.Run();
