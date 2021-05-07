using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;
using WordAnalysis.DataAccess.Services;
using WordAnalysis.Domain.Services;

namespace WordAnalysis
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Builder configuration and dependency injection
            var builder = new ConfigurationBuilder();
            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // WordAnalysisDataService is designed for SQL server connection 
                    services.AddScoped<IWordAnalysisDataService, WordAnalysisDataService>();

                    // WordAnalysisCoreService is where we put our business logic
                    services.AddScoped<IWordAnalysisCoreService, WordAnalysisCoreService>();
                    
                    // This can be improved by moving to appsettings.json
                    services.AddDbContext<WordAnalysis.DataAccess.WordAnalysisContext>(options => options
                        .UseSqlServer("Server=.;Database=WordAnalysis;User ID=sa;Password=Pwd!2345")); 
                })
                .Build();
            

            // Start the application
            Console.WriteLine("Start..");
            var svc = ActivatorUtilities.CreateInstance<WordAnalysisCoreService>(host.Services);
            await svc.PopulateAliasRecords();
            

            Console.WriteLine("End. Please press any key to exit");
            Console.ReadKey();
        }
    }
}
