using System.Text;

using EduRankCR.Application.Common.Interfaces;
using EduRankCR.Infrastructure.Authentication;
using EduRankCR.Infrastructure.Configuration;
using EduRankCR.Infrastructure.Persistence;
using EduRankCR.Infrastructure.Repositories;
using EduRankCR.Infrastructure.Services;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EduRankCR.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services
            .AddDbSettings(configuration)
            .AddEmailSettings(configuration)
            .AddAuth(configuration)
            .AddStorageSettings(configuration)
            .AddPersistence();

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services)
    {
        services.AddSingleton<ITokenRepository, TokenRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        return services;
    }

    private static IServiceCollection AddStorageSettings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var storageSettings = new StorageSettings();
        configuration.Bind(StorageSettings.SectionName, storageSettings);
        services.AddSingleton(Options.Create(storageSettings));
        services.AddSingleton<IStorageService, StorageService>();
        return services;
    }

    private static IServiceCollection AddDbSettings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var dbSettings = new DbSettings();
        configuration.Bind(DbSettings.SectionName, dbSettings);

        services.AddSingleton(Options.Create(dbSettings));
        services.AddSingleton<IDbContext, ApplicationDbContext>();

        return services;
    }

    private static IServiceCollection AddEmailSettings(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var emailSettings = new EmailSettings();
        configuration.Bind(EmailSettings.SectionName, emailSettings);

        services.AddSingleton(Options.Create(emailSettings));
        services.AddSingleton<IEmailService, EmailService>();

        return services;
    }

    private static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var configSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, configSettings);

        var secret = Environment.GetEnvironmentVariable("jwt-secret") ?? configSettings.Secret;
        var issuer = Environment.GetEnvironmentVariable("jwt-issuer") ?? configSettings.Issuer;
        var audience = Environment.GetEnvironmentVariable("jwt-audience") ?? configSettings.Audience;
        var expiry = int.TryParse(Environment.GetEnvironmentVariable("jwt-expiry-minutes"), out var minutes)
            ? minutes
            : configSettings.ExpiryMinutes;

        if (string.IsNullOrWhiteSpace(secret) || secret.Length < 16)
        {
            throw new Exception("JWT secret is missing or too short. Must be at least 16 characters.");
        }

        var jwtSettings = new JwtSettings
        {
            Secret = secret,
            Issuer = issuer,
            Audience = audience,
            ExpiryMinutes = expiry,
        };

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                };
            });

        return services;
    }
}