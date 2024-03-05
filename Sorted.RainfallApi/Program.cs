using System.Reflection;
using Microsoft.OpenApi.Models;

using Sorted.RainfallApi;
using Sorted.RainfallApi.Core.Entities;
using Sorted.RainfallApi.Core.Interfaces;
using Sorted.RainfallApi.Core.Services;
using Sorted.RainfallApi.Core.Services.Interfaces;
using Sorted.RainfallApi.Infrastructure.Services;
using Sorted.RainfallApi.Infrastructure.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppSettings appSettings = builder.Configuration.GetSection("RainfallApi").Get<AppSettings>();
CustomConfigurationManager configurationManager = new CustomConfigurationManager(appSettings);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICustomConfigManager>(configurationManager);
builder.Services.AddScoped<IRainfallService>(s => new RainfallService(s.GetRequiredService<IHttpClientFactory>(), appSettings.RainfallApiEndpoint));
builder.Services.AddScoped(typeof(IRainfallClient), typeof(RainfallClient));
builder.Services.AddControllers( )
    .AddXmlDataContractSerializerFormatters();
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
    var xmlFile = "Sorted.Rain.xml";
    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    s.IncludeXmlComments(xmlCommentsFullPath);
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
