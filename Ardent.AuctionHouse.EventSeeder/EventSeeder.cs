using Amazon.Lambda.Core;
using Ardent.AuctionHouse.EventSeeder.Interfaces;
using Ardent.AuctionHouse.EventSeeder.ServiceProviders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Ardent.AuctionHouse.EventSeeder;

public class EventSeeder
{
    private readonly IServiceProvider _serviceProvider;

    public EventSeeder()
    {
        ServiceCollection services = new();

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        services.AddSingleton<IConfiguration>(configuration);

        EventSeederServiceProvider.ConfigureServices(services);

        _serviceProvider = services.BuildServiceProvider();
    }

    public async Task Seed(ILambdaContext context)
    {
        using IServiceScope scope = _serviceProvider.CreateScope();

        IEventSeeder seeder = scope.ServiceProvider.GetRequiredService<IEventSeeder>();

        const int seedCount = 1000;

        await seeder.Seed(seedCount);
    }
}
