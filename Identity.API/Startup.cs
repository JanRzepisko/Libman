using Identity.Application.DataAccess;
using Identity.Application.EventConsumer;
using Identity.Application.Services;
using Identity.Infrastructure.DataAccess;
using Identity.Infrastructure.Services;
using MassTransit;
using Shared.BaseModels.Jwt;
using Shared.EventBus;
using Shared.Extensions;
using Shared.Messages;

namespace Identity.API;

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
        services.AddSharedServices<Application.AssemblyEntryPoint, IdentityDataContext, IUnitOfWork>(
            JwtLogin.FromConfiguration(Configuration),
            RabbitMQLogin.FromConfiguration(Configuration),
            connectionString,serviceName);
        
        //Configure RabbitMQ
        services.AddMassTransit(c =>
        {
            //Add All Consumers
            c.AddConsumer<ExampleConsumer>();
            c.AddConsumer<AdminSetLibraryConsumer>();
            
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
        services.AddScoped<IJwtGenerator, JwtGenerator>(c => new JwtGenerator(JwtLogin.FromConfiguration(Configuration)));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureApplication(Configuration);
    }
}