namespace FileUpload.Configuration;

public static partial class HostConfiguration
{ 
    public static  ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            //.AddIdentity()
            .AddExposers()
            .AddDevTools();
        return new(builder);
    }
    public static ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        app 
           .UseIdentity()
           .UseDevTools()
           .UseDevTools();
       
       return new(app);
    }
}
