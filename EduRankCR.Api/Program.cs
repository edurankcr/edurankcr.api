using EduRankCR.Api;
using EduRankCR.Application;
using EduRankCR.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://edurankcr.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });
}

var app = builder.Build();
{
    app.UseCors();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}