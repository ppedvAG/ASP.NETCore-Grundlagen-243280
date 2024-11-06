

using FileServer.Middlewares;
using Microsoft.Extensions.FileProviders;

namespace FileServer
{
    public class Program
    {
        public const string FILE_PATH = "files";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var fileProvider = InitFileProvicer(builder.Environment, FILE_PATH);

            // Add services to the container.
            builder.Services.AddControllers();

            var app = builder.Build();

            // Zugriff auf Dateien auf Server ermoeglichen
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = fileProvider,
                RequestPath = $"/{FILE_PATH}"
            });

            // Zum Anzeigen der Dateien im Browser
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = fileProvider,
                RequestPath = $"/{FILE_PATH}"
            });

            app.UseSecuredAccess();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static PhysicalFileProvider InitFileProvicer(IWebHostEnvironment environment, string path)
        {
            var rootPath = Path.Combine(environment.ContentRootPath, path);
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            return new PhysicalFileProvider(rootPath);
        }
    }
}
