using Microsoft.OpenApi.Models;
using Sorted.RainfallApi;
using Sorted.RainfallApi.Models;
using Sorted.RainfallApi.Services;
using Sorted.RainfallApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppSettings appSettings = builder.Configuration.GetSection("RainfallApi").Get<AppSettings>();
CustomConfigurationManager configurationManager = new CustomConfigurationManager(appSettings);

builder.Services.AddSingleton<CustomConfigurationManager>(configurationManager);
builder.Services.AddScoped(typeof(IRainfallService), typeof(RainfallService));
builder.Services.AddHttpClient();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rainfall Api",
        Version = "1.0",
        Contact = new OpenApiContact
        {
            Name = "Sorted",
            Url = new Uri("https://www.sorted.com/")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.yaml", "v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
