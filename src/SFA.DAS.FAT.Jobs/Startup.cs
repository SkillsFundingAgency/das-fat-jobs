using System;
using System.IO;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SFA.DAS.Configuration.AzureTableStorage;
using SFA.DAS.FAT.Jobs.Application.Services;
using SFA.DAS.FAT.Jobs.Domain.Configuration;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FAT.Jobs.Infrastructure.Api;
using SFA.DAS.FATJobs;

[assembly: FunctionsStartup(typeof(Startup))]
namespace SFA.DAS.FATJobs
{
    
    public class Startup : FunctionsStartup
    {
        private IConfiguration _configuration;

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddHttpClient();
            
            var serviceProvider = builder.Services.BuildServiceProvider();
            var configuration =  serviceProvider.GetService<IConfiguration>();
            
            var config = new ConfigurationBuilder()
                .AddConfiguration(configuration)
                .SetBasePath(Directory.GetCurrentDirectory())
#if DEBUG
                .AddJsonFile("local.settings.json", true)
                .AddJsonFile("local.settings.Development.json", true)
#endif
                .AddEnvironmentVariables();

            if (!configuration["EnvironmentName"].Equals("DEV", StringComparison.CurrentCultureIgnoreCase))
            {
                config.AddAzureTableStorage(options =>
                    {
                        options.ConfigurationKeys = configuration["ConfigNames"].Split(",");
                        options.StorageConnectionString = configuration["ConfigurationStorageConnectionString"];
                        options.EnvironmentName = configuration["EnvironmentName"];
                        options.PreFixConfigurationKeys = false;
                    }
                );
            }
            
            _configuration = config.Build();
            builder.Services.AddOptions();
            builder.Services.Configure<FatJobsApiConfiguration>(_configuration.GetSection(nameof(FatJobsApiConfiguration)));
            builder.Services.AddSingleton(cfg => cfg.GetService<IOptions<FatJobsApiConfiguration>>().Value);

            builder.Services.AddSingleton(new FunctionEnvironment(configuration["EnvironmentName"]));

            builder.Services.AddTransient<IShortlistService, ShortlistService>();
            builder.Services.AddHttpClient<IApiClient, ApiClient>();
            
            builder.Services.BuildServiceProvider();
        }
    }
}