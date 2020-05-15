using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Search;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using SearchApp;
using SearchApp.Repository;
using Microsoft.AspNetCore.Identity;

namespace BankApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var iHost = CreateHostBuilder(args).Build();
            InitializeDb(iHost);
            iHost.Run();

        }


        private static void InitializeDb(IHost iHost)
        {
            using (var scope = iHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<BankAppDataContext>();
                var db = new DatabaseInitializer();
                db.Initialize(context);
                db.InitializeBankApp(context, services.GetRequiredService<UserManager<IdentityUser>>());
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
