using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Model;
using System;

namespace EduApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = CreateWebHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                try
                {
                    EduDbContext context = services.GetRequiredService<EduDbContext>();
                    context.Database.Migrate(); // apply all migrations
                    //  SeedInitialize(services); // Insert default data
                }
                catch (Exception ex)
                {
                    ILogger<Program> logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .ConfigureLogging(builder =>
                    builder.AddFile(options =>
                    {
                        options.FileName = "log-"; // The log file prefixes
                        options.LogDirectory = "Log"; // The directory to write the logs
                        options.FileSizeLimit = 20 * 1024 * 1024; // The maximum log file size (20MB here)
                        options.RetainedFileCountLimit = 90;
                    })



                )
                .UseStartup<Startup>();
        }
    }
}
