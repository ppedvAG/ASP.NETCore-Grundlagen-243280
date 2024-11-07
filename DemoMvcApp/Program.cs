using BusinessLogic.Contracts;
using BusinessLogic.Data;
using BusinessLogic.Services;
using DemoMvcApp.Data;

namespace DemoMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IFileService, RemoteFileService>();
            builder.Services.AddSingleton<IRecipeService, SimpleRecipeService>();

            // Wir mappen die Einstellungen aus der appsettings.json nach FileServerOptions
            var fileConfig = builder.Configuration.GetSection("FileServer");
            builder.Services.Configure<FileServiceOptions>(fileConfig);
            builder.Services.AddHttpClient();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSqlServer<DemoDbContext>(connectionString);

            var accountConnectionString = builder.Configuration.GetConnectionString("AccountConnection");
            builder.Services.AddSqlServer<AccountDbContext>(accountConnectionString);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
