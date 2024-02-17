namespace Librista.Api.Configurations;

public static partial class HostConfiguration
{
    public static async Task<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddExposers() // routing, controllers
            .AddDeveloperTools() // ApiExplorer, swagger
            .AddCors() // CORS
            .AddDataBaseProvider() // DbContext
            .AddStorageDependencies() // Registering repositories & data related dependencies
            .AddServiceDependencies()
            .AddMappers()
            .AddValidators()
            .AddRequestContextTools() // HttpContextAccessor
            .AddJsonOptions()
            .AddAuthentication() // JWT
            .AddOthers(); // other utilities
        
        return builder;
    }

    public static async Task<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDeveloperTools() // Swagger
            .UseExposers() // controllers
            .UseCors() // CORS
            .UseAuthenticationMiddleware() // Authentication middleware
            .UseMiddlewares()
            .UseRequestContextTools() // HttpsRedirection
            .UseIdentity() // Identity api endpoints
            .UseOthers() // other utilities
            .UseStaticFiles(); // using static files: wwwroot
        
        return app;
    }
}