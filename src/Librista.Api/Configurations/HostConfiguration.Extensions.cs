using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using Librista.Api.Middlewares;
using Librista.Data.Repositories;
using Librista.Data.Contexts;
using Librista.Data.Repositories.JoiningEntities;
using Librista.Domain.Entities;
using Librista.Service.Interfaces;
using Librista.Service.Models.Mails;
using Librista.Service.Services;
using Librista.Service.Validators.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;

namespace Librista.Api.Configurations;

public partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }
    
    #region WebApplication extensions
    private static WebApplication UseDeveloperTools(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            app.UseHsts();
        }
        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();
        return app;
    }
    private static WebApplication UseMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
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

    private static WebApplication UseAuthenticationMiddleware(this WebApplication app)
    {
        app.UseAuthentication();

        return app;
    }

    private static WebApplication UseIdentity(this WebApplication app)
    {
        app.MapGroup("/api/identity")
            .MapIdentityApi<IdentityUser>();
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

        builder.Services
            .AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDeveloperTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
    private static WebApplicationBuilder AddJsonOptions(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddMvc()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
        return builder;
    }

    private static WebApplicationBuilder AddAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
                options => builder.Configuration.Bind("JwtSettings", options));
        return builder;
    }

    private static WebApplicationBuilder AddIdentity(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<User, Role>(options =>
            {
                // password
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                
                // user
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<LibristaContext>()
            .AddDefaultTokenProviders();
        
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
        builder.Services.AddScoped<IJoiningEntityRepository, JoiningEntityRepository>();
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
        builder.Services.AddScoped<IClientService, ClientService>();

        // mail service
        builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
        builder.Services.AddTransient<IEmailSender<User>, EmailService>();
        
        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        return builder;
    }

    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblies(Assemblies);
        builder.Services.AddScoped<ValidationUtilities>();
        return builder;
    }
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);
        return builder;
    }
    private static WebApplicationBuilder AddOthers(this WebApplicationBuilder builder)
    {
        return builder;
    }
    #endregion
}
