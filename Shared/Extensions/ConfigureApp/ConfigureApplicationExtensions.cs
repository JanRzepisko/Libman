using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shared.PublicMiddlewares;

namespace Shared.Extensions;

public static partial class ConfigureApplicationExtensions
{
    public static IApplicationBuilder ConfigureApplication(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();

        app.UseRouting();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseHttpsRedirection();
        app.UseCors(c => c
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
        
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        app.UseAuthentication();
        app.UseAuthorization();

        //app.UseMiddleware<SetUserMiddleware>();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapSwagger();
            endpoints.MapGet("/" , async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        });
        return app;
    }
}
