using System.Text;

using EduRankCR.Application.Common.Interfaces.Auth;
using EduRankCR.Application.Common.Interfaces.Persistence;
using EduRankCR.Application.Common.Interfaces.Services;
using EduRankCR.Infrastructure.Auth;
using EduRankCR.Infrastructure.Configuration;
using EduRankCR.Infrastructure.Persistence;
using EduRankCR.Infrastructure.Persistence.Repositories;
using EduRankCR.Infrastructure.Service;

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
        services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IInstituteRepository, InstituteRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ISearchRepository, SearchRepository>();

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
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IPasswordHasher, BCryptPasswordHasher>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
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