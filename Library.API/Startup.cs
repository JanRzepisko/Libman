using Library.Application.Actions.Users;
using Library.Application.DataAccess;
using Library.Application.EventConsumer;
using Library.Infrastructure.DataAccess;
using MassTransit;
using MediatR;
using Shared.BaseModels.Jwt;
using Shared.EventBus;
using Shared.Extensions;
using Shared.Messages;

namespace Library.API;

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
        services.AddSharedServices<Application.AssemblyEntryPoint, LibraryDataContext, IUnitOfWork>(
            JwtLogin.FromConfiguration(Configuration),
            RabbitMQLogin.FromConfiguration(Configuration),
            connectionString,serviceName);
        
        //services.AddMediatR(typeof(UserCreatedConsumer).Assembly);;

        //Configure RabbitMQ
        services.AddMassTransit(c =>
        {
            //Add All Consumers
            c.AddConsumer<ExampleConsumer>();
            c.AddConsumer<UserCreatedConsumer>();
            c.AddConsumer<AdminCreatedConsumer>();
            c.AddConsumer<CreatedBookConsumer>();
            c.AddConsumer<UpdatedBookConsumer>();
            c.AddConsumer<RemovedBookConsumer>();
            
            c.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host("host.docker.internal", h =>
                {
                    h.Username("libman");
                    h.Password("!Malinka@pass");
                });
                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.ConfigureApplication(Configuration);
    
}