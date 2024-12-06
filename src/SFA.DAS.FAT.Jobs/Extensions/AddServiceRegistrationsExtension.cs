using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SFA.DAS.FAT.Jobs.Application.Services;
using SFA.DAS.FAT.Jobs.Domain.Configuration;
using SFA.DAS.FAT.Jobs.Domain.Interfaces;
using SFA.DAS.FAT.Jobs.Infrastructure.Api;

namespace SFA.DAS.FAT.Jobs.Extensions;

public static class AddServiceRegistrationsExtension
{
    public static IServiceCollection AddServiceRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterServices()
            .AddHttpClient()
            .RegisterHttpClients()
            .BindConfiguration(configuration);

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IShortlistService, ShortlistService>();
        return services;
    }

    private static IServiceCollection RegisterHttpClients(this IServiceCollection services)
    {
        services.AddHttpClient<IApiClient, ApiClient>();
        return services;
    }

    private static IServiceCollection BindConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<FatJobsApiConfiguration>(configuration.GetSection(nameof(FatJobsApiConfiguration)));
        services.AddSingleton(cfg => cfg.GetService<IOptions<FatJobsApiConfiguration>>()!.Value);
        services.AddSingleton(new FunctionEnvironment(configuration["EnvironmentName"]!));
        return services;
    }
}
