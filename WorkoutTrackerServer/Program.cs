using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "WorkoutTracker API",
        Version = "v1",
        Description = "API for tracking workouts",
        Contact = new OpenApiContact
        {
            Name = "Bálint Boda",
            Email = "bodabalint04@gmail.com",
        }
    });

    config.CustomOperationIds(apiDescription =>
        apiDescription.TryGetMethodInfo(out var methodInfo) ? methodInfo.Name : null);
    
    config.IncludeXmlComments(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config => { config.DisplayOperationId(); });
}

app.Logger.LogInformation("Swagger UI running at: ");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();