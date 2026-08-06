using Amazon;
using Amazon.RDS.Util;
using Ardent.AuctionHouse.EventSeeder.Interfaces;
using Ardent.AuctionHouse.EventSeeder.Services;
using Ardent.AuctionHouse.Repository.Context;
using Ardent.AuctionHouse.Repository.Events;
using Ardent.AuctionHouse.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Microsoft.EntityFrameworkCore;

namespace Ardent.AuctionHouse.EventSeeder.ServiceProviders;

public class EventSeederServiceProvider
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IEventSeeder, EventSeederService>();
        services.AddScoped<IEventsRepository, EventsRepository>();

        services.AddDbContext<AuctionHouseDbContext>((sp, options) =>
        {
            IConfiguration config = sp.GetRequiredService<IConfiguration>();

            NpgsqlConnectionStringBuilder builder = new(
                config.GetConnectionString("AuctionHouse"));

            builder.Password = RDSAuthTokenGenerator.GenerateAuthToken(
                hostname: builder.Host,
                port: builder.Port,
                dbUser: builder.Username,
                region: RegionEndpoint.EUNorth1);

            options.UseNpgsql(builder.ConnectionString);
        });

    }
}
