using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieSurvivalSocialNetwork.Infrastructure.Contexts;

namespace ZombieSurvivalSocialNetwork
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host=CreateHostBuilder(args).Build();
            try
            {
                using (var scope = host.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<ZombieDbContext>();
                    db.Database.Migrate();
                }
                host.Run();

            }
            catch (Exception ex)
            {
                //log error
                return;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
