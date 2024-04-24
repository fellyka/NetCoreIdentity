using IdentityApp.Model;
using Microsoft.EntityFrameworkCore;

namespace IdentityApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


            var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("IdentityApp"));
            });



            var app = builder.Build();

            app.UseStaticFiles();
            //app.UseEndpoints(endpoints => {
            //    endpoints.MapDefaultControllerRoute();
            //    endpoints.MapRazorPages();
            //});

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

           // app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}//35
