using System;
using System.IO;
using System.Reflection;
using email_proxy.Common.Options;
using email_proxy.GrpcProcedure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

namespace email_proxy.Extensions;

public static class WebApplicationBuilderExtension
{
    private const string JwtConfigurationsSectionKey = "JwtConfigurations";
    
    public static WebApplicationBuilder AddConfigurationByEnvironment(this WebApplicationBuilder builder)
    {
#if DEBUG || LOCAL
        var currentConfigName = $"appsettings.json";
        var assemblyName = Assembly.GetExecutingAssembly().GetName().Name!;
        var pathToConfig = Path.GetFullPath($"../{assemblyName}-config");
        var fullPath = Path.Join(pathToConfig, currentConfigName);
        if (File.Exists(fullPath))
        {
            builder.Configuration.AddJsonFile(
                new PhysicalFileProvider(pathToConfig),
                currentConfigName, true, false);
        }
#endif
        return builder;
    }
    
    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        var jwtSections = builder.Configuration.GetRequiredSection(JwtConfigurationsSectionKey)
            .Get<JwtAuthOptions>()!;
        builder.Services.AddAuthenticationAndAuthorization(jwtSections);
    }
    
    public static void UseGrpcEndpoints(this WebApplication app)
    {
        app.MapGrpcService<EmailSendService>();
    }
}