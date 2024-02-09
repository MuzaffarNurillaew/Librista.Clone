using Librista.Data.Repositories;
using Librista.Data.Contexts;
using Librista.Service.Interfaces;
using Librista.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace Librista.Api.Configurations;

public partial class HostConfiguration
{
    #region WebApplication extensions

    private static WebApplication UseDeveloperTools(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }

    private static WebApplication UseCors(this WebApplication app)
    {
        app.UseCors("LibristaOrigin");
        return app;
    }

    private static WebApplication UseRequestContextTools(this WebApplication app)
    {
        app.UseHttpsRedirection();
        return app;
    }

    private static WebApplication UseOthers(this WebApplication app)
    {
        return app;
    }
    #endregion

    #region WebApplicationBuilder extensions

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true;
        });

        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDeveloperTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
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

    private static WebApplicationBuilder AddDataBaseProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LibristaContext>(options =>
        {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        return builder;
    }

    private static WebApplicationBuilder AddStorageDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IRepository, Repository>();
        return builder;
    }

    private static WebApplicationBuilder AddServiceDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAddressService, AddressService>();
        builder.Services.AddScoped<IAuthorService, AuthorService>();
        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBorrowingRecordService, BorrowingRecordService>();
        builder.Services.AddScoped<ICityService, CityService>();
        builder.Services.AddScoped<ICountryService, CountryService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IPublisherService, PublisherService>();

        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        return builder;
    }

    private static WebApplicationBuilder AddOthers(this WebApplicationBuilder builder)
    {
        return builder;
    }
    #endregion
}
