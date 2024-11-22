using email_proxy.Common.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace email_proxy.Extensions;

public static class OptionsExtension
{
    public static void AddOptions(this WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.Configure<JwtAuthOptions>(builder.Configuration.GetSection(JwtAuthOptions.Key));
        services.Configure<SmtpClientOptions>(builder.Configuration.GetSection(SmtpClientOptions.Key));
    }
}