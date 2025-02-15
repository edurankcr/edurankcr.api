using FluentValidation;
using FluentValidation.AspNetCore;

namespace EduRankCR.API.Extensions
{
    public static class ValidationExtension
    {
        public static IServiceCollection AddApplicationValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<RequestUserCreateDtoValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            return services;
        }
    }
}