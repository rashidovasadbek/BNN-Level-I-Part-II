using N64.Identity.Application.Common.Settings;
using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Infrastructure.Common.Idenitty.Servises;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using N64.Identity.Infrastructure.Common.Identity.Services;

namespace N64.Identity.Api.Configuration;

public static partial class HostConfiguration
{
    public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

        builder.Services.AddTransient<ITokenGeneratorService, TokenGeneratorService>();
        builder.Services.AddTransient<IPasswordHasherService, PasswordHasherService>();

        builder.Services.AddScoped<IAuthService, AuthService>();


        var jwtSettings = new JwtSettings();
        builder.Configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);

        builder
            .Services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(optoins =>
            {
                optoins.RequireHttpsMetadata = false;

                optoins.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = jwtSettings.ValidateIssuer,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidateAudience = jwtSettings.ValidateAudience,
                    ValidAudience = jwtSettings.ValidAudience,
                    ValidateLifetime = jwtSettings.ValidateLifetime,
                    ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                };

            });

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

    public static WebApplication UseIdentityInfrastructure(this WebApplication app)
    {
        app.UseAuthentication();
        app.UseAuthorization();
        
        return app;
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