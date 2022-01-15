using Tatyrkova.Eshop.Web.Models.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Tatyrkova.Eshop.Web.Models.Identity;

namespace Tatyrkova.Eshop.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            IHost host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                if (scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
                {
                    EshopDbContext dbContext = scope.ServiceProvider.GetRequiredService<EshopDbContext>();
                    DatabaseInit dbInit = new DatabaseInit();
                    dbInit.Initialization(dbContext);

                    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                    await dbInit.EnsureRoleCreated(roleManager);

                    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

                    await dbInit.EnsureAdminCreated(userManager);
                    await dbInit.EnsureManagerCreated(userManager);



                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(loggingBuilder =>
                {
                    loggingBuilder.ClearProviders();
                    loggingBuilder.AddFile("Logs/eshop-log-{Date}.txt");
                });


    }



}


