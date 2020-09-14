using System;
using HelloDarlingMVC2.Areas.Identity.Data;
using HelloDarlingMVC2.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HelloDarlingMVC2.Areas.Identity.IdentityHostingStartup))]
namespace HelloDarlingMVC2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HelloDarlingMVC2Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HelloDarlingMVC2ContextConnection")));

                services.AddDefaultIdentity<HelloDarlingMVC2User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<HelloDarlingMVC2Context>();
            });
        }
    }
}