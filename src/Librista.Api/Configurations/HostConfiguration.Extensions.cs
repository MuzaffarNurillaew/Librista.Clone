using Librista.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Librista.Api.Configurations;

public partial class HostConfiguration
{
    #region WebApplication extensions
    public static WebApplication UseDeveloperTools(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }

    public static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }

    public static WebApplication UseCors(this WebApplication app)
    {
        app.UseCors("LibristaOrigin");
        return app;
    }

    public static WebApplication UseRequestContextTools(this WebApplication app)
    {
        app.UseHttpsRedirection();
        return app;
    }
    public static WebApplication UseOthers(this WebApplication app)
    {
        return app;
    }
    #endregion

    #region WebApplicationBuilder extensions
    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        builder.Services.AddControllers();

        return builder;
    }

    public static WebApplicationBuilder AddDeveloperTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    public static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "LibristaOrigin",
                policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
        });

        return builder;
    }

    public static WebApplicationBuilder AddDataBaseProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LibristaContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        return builder;
    }

    public static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        return builder;
    }
    public static WebApplicationBuilder AddOthers(this WebApplicationBuilder builder)
    {
        return builder;
    }
    #endregion
}
