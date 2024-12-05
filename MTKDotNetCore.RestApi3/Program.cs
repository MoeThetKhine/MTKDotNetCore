var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection for HttpClient

builder.Services.AddSingleton(n => new HttpClient()
{
    BaseAddress = new Uri(builder.Configuration.GetSection("ApiDomainUrl").Value!)
});

#endregion

#region Dependency Injection for RestClient

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

app.UseAuthorization();

app.MapControllers();

app.Run();

#region ISnakeApi

public interface ISnakeApi
{
    [Get("/snakes")]
    Task<List<SnakeModel>> GetSnakes();
}

#endregion

#region SnakeModel

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

#endregion