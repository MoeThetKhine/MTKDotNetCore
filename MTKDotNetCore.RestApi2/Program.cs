using Microsoft.AspNetCore.Mvc;
using RestSharp;

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

app.MapGet("/pick-a-pile", async ([FromServices] RestClient restClient) =>
{
    RestRequest request = new RestRequest("pick-a-pile", Method.Get);
    var response = await restClient.GetAsync(request);
    return response.Content;
});

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
