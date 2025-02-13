using System.Text.Json.Serialization;
using API.EduRankCR.API.Repositories;
using API.EduRankCR.API.Services;
using API.EduRankCR.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
Log.Logger = new LoggerConfiguration().WriteTo
    .Console()
    .WriteTo.File("Logs/Log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Host.UseSerilog();

// Add services to the DI container
builder.Services
    .AddControllers()
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            options.JsonSerializerOptions.WriteIndented = true;
        }
    );


// Configure OpenAPI
builder.Services.AddOpenApi();

// Configure database
var connectionString = Environment.GetEnvironmentVariable("env-databaseconnection") ?? builder.Configuration.GetConnectionString("DatabaseConnection");

builder.Services.AddDbContext<APIEduRankCRContext>(
    options => options.UseSqlServer(connectionString)
);

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Enable CORS
builder.Services.AddCors(
    options =>
    {
        options.AddPolicy(
            "AllowAll",
            policy =>
            {
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
            }
        );
    }
);

// Enable Model State
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Add health checks
builder.Services.AddHealthChecks();
var app = builder.Build();

// Global Exception Handling
app.UseExceptionHandler(
    errorApp =>
    {
        errorApp.Run(
            async context =>
            {
                context.Response.ContentType = "application/json";
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionHandlerPathFeature?.Error is not null)
                {
                    var errorResponse = new
                    {
                        Message = "An unexpected error occurred.",
                        Details = exceptionHandlerPathFeature.Error.Message
                    };
                    await context.Response.WriteAsJsonAsync(errorResponse);
                }
            }
        );
    }
);

// Enable Swagger in Development
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

// Apply middleware
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("/health");

// Run the application
app.Run();
