using DocumentConverter.Infrastructure.Services.DocumentConverter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentConverter.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<DocumentConverterServiceFactory>();

        return services;
    }
}
