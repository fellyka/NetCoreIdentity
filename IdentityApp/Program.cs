using IdentityApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore

namespace IdentityApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();


            var mySqlConnectionString = builder.Configuration.GetConnectionString("MySqlConnection");
            //var SqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");

            /*MySql*/
            builder.Services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString), b => b.MigrationsAssembly("IdentityApp"));
            });

            /*Sql Server*/
            //builder.Services.AddDbContext<ProductDbContext>(options =>
            //{
            //    options.UseSqlServer(SqlServerConnectionString, b => b.MigrationsAssembly("IdentityApp"));
            //});

           

            /*-------------------------------------------------------------------------------------------------------------------------------------*/
            /*Here, we configure the application to set up the database that will be used to store user data and to configure ASP.NET Core Identity*/
            var mySqlIdentityConnection = builder.Configuration.GetConnectionString("IdentityMySqlConnection");

            /*The AddDbContext method is used to set up an Entity Framework Core database context for Identity
              The database context class is IdentityDbContext, which is included in the Identity packages and includes
              details of the schemathat will be used to store identity data. 
              Remember, IdetityDbContext class is defined in a different assembly, I have to tell EF Core 
              to create databse migrations in the IdentityApp project
             */
            builder.Services.AddDbContext<IdentityDbContext>(options =>
            {
                options.UseMySql(mySqlIdentityConnection, ServerVersion.AutoDetect(mySqlIdentityConnection), b => b.MigrationsAssembly("IdentityApp"));
            });

            
            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<IdentityDbContext>();

            /*-------------------------------------------------------------------------------------------------------------------------------------*/



            /*Enable HHTPS redirection - Before that, Generate a Test cerficate using the code below in the Package Manager Console in your Visual Studio:
                   -dotnet dev-certs https --clean
                   -dotnet dev-certs https --trust
          Note: This certificate is used for DEVELOPMENT Only. For Production, A real certificate is required (Please, visit https://letsencrypt.org/ for more info)
           */
            builder.Services.AddHttpsRedirection(opts => { opts.HttpsPort = 44350; });



            var app = builder.Build();

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            //app.UseEndpoints(endpoints => {
            //    endpoints.MapDefaultControllerRoute();
            //    endpoints.MapRazorPages();
            //});

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

           // app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}//35
