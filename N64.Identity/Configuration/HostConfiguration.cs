namespace N64.Identity.Api.Configuration;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder.AddIdentityInfrastructure().AddDevTools().AddExposers();
        return new(builder);
    }

    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app.UseIdentityInfrastructure().UserDevTools().UseExposers();
        return new(app);
    }
}
