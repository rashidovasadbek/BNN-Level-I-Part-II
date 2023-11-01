using Microsoft.EntityFrameworkCore;
using N66.LibraryManagement.Application.Services;
using N66.LibraryManagement.Domin.Entities.Models;
using N66.LibraryManagement.Infrastucture.Services;
using N66.LibraryManagement.Persistance.DataContext;

namespace N66.LibraryManagement.Api.Configurations;

public static partial class HostConfiguration
{

    public static WebApplicationBuilder AddPersistance(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDBContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        return builder;
    }
    public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IEntityBaseService<Author>, AutherService>();
        builder.Services.AddScoped<IEntityBaseService<Book>, BookService>();
        
        return builder;
    }
    public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen();
        builder.Services.AddEndpointsApiExplorer();

        return builder;
    }

    public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    public static WebApplication UserDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }

    public static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}
