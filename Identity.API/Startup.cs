using Identity.Application.DataAccess;
using Identity.Application.Services;
using Identity.Infrastructure.DataAccess;
using Identity.Infrastructure.Services;
using Shared.BaseModels.Jwt;
using Shared.Extensions;

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
        services.AddSharedServices<Application.AssemblyEntryPoint, IdentityDataContext, IUnitOfWork>(JwtLogin.FromConfiguration(Configuration), Configuration["ConnectionString"], Configuration["ServiceName"]);
        
        //Add application services here.
        services.AddScoped<IJwtGenerator, JwtGenerator>(c => new JwtGenerator(JwtLogin.FromConfiguration(Configuration)));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) => app.ConfigureApplication();
    
    

}