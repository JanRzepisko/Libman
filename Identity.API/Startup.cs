using Identity.Application.DataAccess;
using Identity.Application.EventConsumer;
using Identity.Application.Services;
using Identity.Infrastructure.DataAccess;
using Identity.Infrastructure.Services;
using MassTransit;
using MassTransit.Configuration;
using MassTransit.RabbitMqTransport.Configuration;
using RabbitMQ.Client;
using Shared.BaseModels.Jwt;
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
            c.AddConsumer<HelloWordEventConsumer>();
            
            c.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("localhost", h =>
                {
                    h.Username("libman");
                    h.Password("!Malinka@pass");
                });
                
                //Add All Consumers
                cfg.CreateQueue<HelloWordEventConsumer>(serviceName, ctx);
            });
        });

        services.AddScoped<IJwtGenerator, JwtGenerator>(c => new JwtGenerator(JwtLogin.FromConfiguration(Configuration)));
        
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureApplication();
    }
}