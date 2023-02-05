using Identity.Application.DataAccess;
using Identity.Infrastructure.DataAccess;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.HttpOverrides;
using Shared.BaseModels.Jwt;
using Shared.Extensions;
using Shared.PublicMiddlewares;

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
        services.Configure<string>(Configuration);

        var jwtLogin = new JwtLogin
        {
            Audience = Configuration["Jwt:Audience"],
            Issuer = Configuration["Jwt:Issuer"],
            Key = Configuration["Jwt:Key"],
        };

        services.AddSharedServices<Application.AssemblyEntryPoint, IdentityDataContext, IUnitOfWork>(jwtLogin, Configuration["ConnectionString"], Configuration["ServiceName"]);
        Console.WriteLine("Token: " + Configuration["Jwt:Key"]);
        Console.WriteLine("ConnectionString: " + Configuration["ConnectionString"]);
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.ConfigureApplication();
        
        //Use custom middleware for microservice
        //app.UseMiddleware<SetUserMiddleware>();
    }
}