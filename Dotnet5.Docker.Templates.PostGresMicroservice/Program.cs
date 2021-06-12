// -----------------------------------------------------------------------
// <copyright company="N/A." file="Program.cs">
// </copyright>
// <author>
// Thomas Fletcher, Average Developer
// tom@tomfletcher.tech
// </author>
// -----------------------------------------------------------------------

#region usings
using System;
using System.Threading.Tasks;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Data;
using Dotnet5.Docker.Templates.PostGresMicroservice.Persistence.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
#endregion

namespace Dotnet5.Docker.Templates.PostGresMicroservice
{
    public class Program
    {
        // This is the original way of starting up a project 
        // public static void Main(string[] args)
        // {
        //     CreateHostBuilder(args).Build().Run();
        // }
        //
        // public static IHostBuilder CreateHostBuilder(string[] args) =>
        //     Host.CreateDefaultBuilder(args)
        //         .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); }); 
        
        
        // This way, we will create the Database if it's not already created & update it's context.
        // You don't need to do 'dotnet ef database update'
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
        
            using var scope = host.Services.CreateScope();
        
            var services = scope.ServiceProvider;
        
            try 
            {
                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();
                await TodoSeedDataContext.SeedData(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migraiton");
            }
        
            await host.RunAsync();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}