using Serilog;

namespace EduRankCR.Infrastructure.Logging
{
    public static class SerilogConfiguration
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}