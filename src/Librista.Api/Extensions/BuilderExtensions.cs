using Librista.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Librista.Api.Extensions;

public static class BuilderExtensions
{
    public static WebApplicationBuilder RegisterDatabaseProvider(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LibristaContext>(options =>
        {
            options.UseSqlite("Data Source=Application.db");
        });

        return builder;
    }
}