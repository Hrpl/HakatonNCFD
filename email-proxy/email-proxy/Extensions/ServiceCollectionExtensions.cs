using System.Reflection;
using email_proxy.Common.Options;
using email_proxy.Service.Implementation;
using email_proxy.Service.Interface;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace email_proxy.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAuthenticationAndAuthorization(this IServiceCollection services,
        JwtAuthOptions jwtOptions)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = jwtOptions.Issuer,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    IssuerSigningKey = jwtOptions.GetSymmetricSecurityKey(),
                    ValidateLifetime = jwtOptions.ValidateLifeTime,
                    CryptoProviderFactory = new CryptoProviderFactory()
                    {
                        CacheSignatureProviders = false
                    }
                };
            });

        services.AddAuthorization();
    }
    
    public static void AddMapper(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        var mapperConfig = new Mapper(config);
        services.AddSingleton<IMapper>(mapperConfig);
    }

    public static void AddService(this IServiceCollection services)
    {
        services.AddGrpc();
        
        services.AddScoped<IEmailService, EmailService>();
    }
}