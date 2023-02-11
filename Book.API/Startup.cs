using System.Net.Mime;
using Book.Application.DataContext;
using Book.Application.EventConsumers;
using Book.Infrastructure.DataContext;
using MassTransit;
using Shared;
using Shared.BaseModels.Jwt;
using Shared.EventBus;
using Shared.Extensions;

namespace Book.API;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        string connectionString = Configuration["ConnectionString"];
        string serviceName = Configuration["ServiceName"];

        //Configure Service
        services.Configure<string>(Configuration);
        services.AddSharedServices<Application.AssemblyEntryPoint, BookDataContext, IUnitOfWork>(
            JwtLogin.FromConfiguration(Configuration),
            RabbitMQLogin.FromConfiguration(Configuration),
            connectionString,serviceName);
        
        //Configure RabbitMQ
        services.AddMassTransit(c =>
        {
            //Add All Consumers
            c.AddConsumer<ChangedBookStatusConsumer>();
            
            c.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("host.docker.internal", h =>
                {
                    h.Username("libman");
                    h.Password("!Malinka@pass");
                });
                
                //Add All Consumers
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureApplication(Configuration);
    }
}