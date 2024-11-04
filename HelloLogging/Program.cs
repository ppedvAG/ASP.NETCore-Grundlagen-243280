using Serilog;

namespace HelloLogging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("app.log", rollingInterval: RollingInterval.Day)
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();
            builder.Host.UseSerilog();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
