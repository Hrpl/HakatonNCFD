using EmailProxy;
using FastEndpoints;
using Grpc.Core;
using Grpc.Net.Client;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using UserService.API.Services.Implementations;
using UserService.API.Services.Interfaces;
using UserService.Infrastructure.Repositories.Implementations;
using UserService.Infrastructure.Repositories.Interfaces;
using UserService.Infrastructure.Services.Implementations;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Extensions;

public static class AddServiceExtensions
{
    public static void AddService(this IServiceCollection services)
    {
        services.AddFastEnpoint();
        services.AddMapster();
        services.AddRegisterService();
    }

    public static void AddGrpcWithConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var emailService = new Uri(configuration["Services:EmailService:Address"]!);

        services.AddGrpc();
        services.AddGrpcClient<EmailSendService.EmailSendServiceClient>(o => o.Address = emailService);
    }

    public static void AddJwt(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["JwtConfigurations:Issuer"],
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfigurations:Key"])),
                ValidateIssuerSigningKey = true
            };
        });
        builder.Services.AddAuthorization();
    }

    public static void AddMapster(this IServiceCollection services)
    {
        TypeAdapterConfig config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        Mapper mapperConf = new(config);
        services.AddSingleton<IMapper>(mapperConf);
    }

    public static void AddFastEnpoint(this IServiceCollection services)
    {
        services.AddFastEndpoints();
        services.AddSwaggerDocument();
    }

    public static void AddRegisterService(this IServiceCollection services)
    {
        services.AddScoped<IJwtHelper, JwtHelper>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IDbConnectionManager, DbConnectionManager>();
        services.AddScoped<IAsyncRepository, AsyncRepository>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEmailEventService, EmailEventService>();
        services.AddScoped<IUserProfileService,  UserProfileService>();
    }
}
