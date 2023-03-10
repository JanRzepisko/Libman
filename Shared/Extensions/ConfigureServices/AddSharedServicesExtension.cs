using System.Configuration;
using System.Reflection;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.BaseModels.Jwt;
using Shared.Behaviours;
using Shared.EventBus;
using Shared.Service.Implementations;
using Shared.Service.Interfaces;

namespace Shared.Extensions;

public static partial class AddSharedServicesExtension
{
    public static IServiceCollection AddSharedServices<AssemblyEntryPoint, DataContext, UnitOfWork>(this IServiceCollection services, JwtLogin jwtLogin, RabbitMQLogin rabbitMqLogin, string connectionString, string serviceName) 
        where DataContext : DbContext, UnitOfWork where UnitOfWork : class
    {
        services.AddEndpointsApiExplorer();
        services.AddMediatR(typeof(AssemblyEntryPoint).GetTypeInfo().Assembly);
        services.AddFluentValidators(typeof(AssemblyEntryPoint).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(ValidationBehaviour<,>));

        services.AddDatabase<DataContext, UnitOfWork>(connectionString);
        services.AddFluentValidators(typeof(AssemblyEntryPoint).Assembly);
        services.AddJwtAuthorization(jwtLogin);
        services.AddSwagger(serviceName);
        services.AddOptions();

        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policyBuilder => policyBuilder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());
        });
        
        //Add Logging
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));

        services.AddControllers();

        
        
        //Add Services
        services.AddTransient<IEventBus, EventBus.EventBus>();
        services.AddScoped<IUserProvider, UserProvider>();
        //services.AddScoped<IFileManager, FileManager>();
        
        return services;
    }
}