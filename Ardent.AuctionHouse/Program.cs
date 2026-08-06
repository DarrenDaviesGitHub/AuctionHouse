using Ardent.AuctionHouse.Middleware;
using Ardent.AuctionHouse.Repository.Context;
using Ardent.AuctionHouse.Repository.Events;
using Ardent.AuctionHouse.Repository.Interfaces;
using Amazon;
using Amazon.RDS.Util;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Scalar.AspNetCore;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddProblemDetails();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource =>
    {
        resource.AddService(
        serviceName: builder.Environment.ApplicationName,
        serviceVersion: "1.0.0"
        );
    })
    .WithTracing(tracing =>
    {
        tracing
            .AddAspNetCoreInstrumentation(options =>
            {
                options.RecordException = true;
            })
            .AddHttpClientInstrumentation()
            .AddEntityFrameworkCoreInstrumentation()
            .AddSource(nameof(Ardent.AuctionHouse))
            .AddOtlpExporter(options =>
            {
                options.Endpoint = new Uri(builder.Configuration["OpenTelemetry:Otlp:Endpoint"]!);
            });
    });

builder.Services.AddDbContext<AuctionHouseDbContext>((services, options) =>
{
    var configuration = services.GetRequiredService<IConfiguration>();

    var builder = new NpgsqlConnectionStringBuilder(
        configuration.GetConnectionString("AuctionHouse"));

    builder.Password = RDSAuthTokenGenerator.GenerateAuthToken(
        hostname: builder.Host,
        port: builder.Port,
        dbUser: builder.Username,
        region: RegionEndpoint.EUNorth1);

    options.UseNpgsql(builder.ConnectionString);
});

builder.Services.AddScoped<IEventsRepository, EventsRepository>();

builder.Services.AddRateLimiter(options =>
{
    options.AddPolicy("RateLimitPerIPAddress", httpContext =>
    {
        var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: ipAddress,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 500,
                Window = TimeSpan.FromMinutes(1),
                QueueLimit = 0
            });
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseRateLimiter();

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers()
   .RequireRateLimiting("RateLimitPerIPAddress");

app.Run();
