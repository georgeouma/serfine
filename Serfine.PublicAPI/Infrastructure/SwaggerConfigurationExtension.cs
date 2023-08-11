using Microsoft.OpenApi.Models;

namespace Serfine.PublicAPI.Infrastructure;

public static class SwaggerConfigurationExtension
{
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        
    }

    public static void UseSwaggerExtension(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}