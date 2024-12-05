
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection for HttpClient

builder.Services.AddSingleton(n => new HttpClient()
{
    BaseAddress = new Uri(builder.Configuration.GetSection("ApiDomainUrl").Value!)
});

#endregion

#region Dependency Injection for HttpRestClient

builder.Services.AddSingleton(n =>
new RestClient(builder.Configuration.GetSection("ApiDomainUrl").Value!));

#endregion

#region Dependency Injection for RefitClient

builder.Services
    .AddRefitClient<ISnakeApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(builder.Configuration.GetSection("ApiDomainUrl").Value!));

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Birds Get

app.MapGet("/birds", async ([FromServices] HttpClient httpClient) =>
{
    var response = await httpClient.GetAsync("birds");
    return await response.Content.ReadAsStringAsync();
});

#endregion

#region Pick a Pile

app.MapGet("/pick-a-pile", async ([FromServices] RestClient restClient) =>
{
    RestRequest request = new RestRequest("pick-a-pile", Method.Get);
    var response = await restClient.GetAsync(request);
    return response.Content;
});

#endregion

app.MapGet("/snakes", async ([FromServices] ISnakeApi snakeApi) =>
{
    var response = await snakeApi.GetSnakes();
    return response;
});

app.Run();



public interface ISnakeApi
{
    [Get("/snakes")]
    Task<List<SnakeModel>> GetSnakes();
}


public class SnakeModel
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string MMName { get; set; }
    public string EngName { get; set; }
    public string Detail { get; set; }
    public string IsPoison { get; set; }
    public string IsDanger { get; set; }
}

