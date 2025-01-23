var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddSingleton<DapperService>(sp => new DapperService(connectionString));

builder.Services.AddScoped<DataAccess_User>();
builder.Services.AddScoped<BusinessLogic_User>();
builder.Services.AddScoped<DataAccess_Withdraw>();
builder.Services.AddScoped<BusinessLogic_Withdraw>();
builder.Services.AddScoped<DataAccess_Deposit>();
builder.Services.AddScoped<BusinessLogic_Deposit>();
builder.Services.AddScoped<DataAccess_Transaction>();
builder.Services.AddScoped<BusinessLogic_Transaction>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mini Kpay API v1"));
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
