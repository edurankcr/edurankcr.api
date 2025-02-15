using System.Text;
using EduRankCR.API.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using EduRankCR.Application.Interfaces;
using EduRankCR.Application.Services;
using EduRankCR.Infrastructure.Data;
using EduRankCR.Infrastructure.Mappings;
using EduRankCR.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Serilog
ConfigureSerilog(builder);

// Services
ConfigureServices(builder);

// Build the app
var app = builder.Build();

// Middleware
ConfigureMiddleware(app);

app.Run();

void ConfigureSerilog(WebApplicationBuilder applicationBuilder)
{
    applicationBuilder.Host.UseSerilog((ctx, lc) => lc
        .ReadFrom.Configuration(ctx.Configuration));
}

void ConfigureServices(WebApplicationBuilder applicationBuilder)
{
    var config = applicationBuilder.Configuration;

    ConfigureAuthentication(applicationBuilder, config);

    applicationBuilder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
    applicationBuilder.Services.AddControllers();
    applicationBuilder.Services.Configure<ApiBehaviorOptions>(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });
    applicationBuilder.Services.AddEndpointsApiExplorer();
    applicationBuilder.Services.AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Enter 'token' as the value. You can get this token from the login endpoint."
        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                []
            }
        });
    });
    
    applicationBuilder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
    });

    applicationBuilder.Services.AddApplicationValidation();
    applicationBuilder.Services.AddAutoMapper(typeof(MappingProfile));
    applicationBuilder.Services.AddScoped<IUserService, UserService>();
    applicationBuilder.Services.AddScoped<IUserRepository, UserRepository>();
    applicationBuilder.Services.AddSingleton<IConnectionFactory, SqlConnectionFactory>();
}

void ConfigureAuthentication(WebApplicationBuilder applicationBuilder, IConfiguration config)
{
    var jwtSettings = config.GetSection("Jwt");
    var key = Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? throw new InvalidOperationException("JWT Key not found"));

    applicationBuilder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                ValidateLifetime = true
            };
        });
}

void ConfigureMiddleware(WebApplication webApplication)
{
    if (webApplication.Environment.IsDevelopment())
    {
        webApplication.UseSwagger();
        webApplication.UseSwaggerUI();
    }

    webApplication.UseMiddleware<ExceptionHandlingMiddleware>();
    webApplication.UseCors("AllowAll");
    webApplication.UseHttpsRedirection();
    webApplication.UseAuthentication();
    webApplication.UseAuthorization();
    webApplication.MapControllers();
}
