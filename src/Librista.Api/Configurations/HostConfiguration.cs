namespace Librista.Api.Configurations;

public static partial class HostConfiguration
{
    public static async Task<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddExposers()
            .AddDeveloperTools()
            .AddCors()
            .AddDataBaseProvider()
            .AddRequestContextTools()
            .AddOthers();
        
        return builder;
    }

    public static async Task<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app
            .UseDeveloperTools()
            .UseExposers()
            .UseCors()
            .UseOthers()
            .UseRequestContextTools()
            .UseStaticFiles();
        
        return app;
    }
}