using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloDarlingMVC3.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HelloDarlingMVC3
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;

            //    try
            //    {
            //        using (var context = new ApplicationDbContext(
            //            services.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            //        {
            //            context.Database.EnsureDeleted();
            //        }
            //    }
            //    catch (Exception)
            //    {

            //        throw;
            //    }
            //}
            host.Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
