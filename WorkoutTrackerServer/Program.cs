using System.Reflection;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using WorkoutTrackerServer.Exercises.Repository;
using WorkoutTrackerServer.Exercises.Service;
using WorkoutTrackerServer.Persistence;
using WorkoutTrackerServer.Workouts.Repository;
using WorkoutTrackerServer.Workouts.Service;

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

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WorkoutContext")));

builder.Services.AddScoped<IWorkoutService, WorkoutService>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IExerciseService, ExerciseService>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config => { config.DisplayOperationId(); });
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DatabaseContext>();
    // DbInitializer.Initialize(context);
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();