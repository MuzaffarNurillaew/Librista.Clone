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
            .AddRequestContextTools() // HttpContextAccessor
            .AddOthers(); // other utilities
        
        return builder;
    }

    public static async Task<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDeveloperTools() // Swagger
            .UseExposers() // controllers
            .UseCors() // CORS
            .UseRequestContextTools() // HttpsRedirection
            .UseOthers() // other utilities
            .UseStaticFiles(); // using static files: wwwroot
        
        return app;
    }
}