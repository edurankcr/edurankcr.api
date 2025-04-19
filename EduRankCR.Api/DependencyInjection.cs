using EduRankCR.Api.Common.Errors;
using EduRankCR.Api.Common.Filters;
using EduRankCR.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EduRankCR.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.Filters.Add<RequireUserIdClaimFilter>();
        });
        services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}