using email_proxy.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.AddConfigurationByEnvironment();
builder.AddJwtAuthentication();
builder.AddOptions();

// Регистрация сервисов.
IServiceCollection services = builder.Services;
services.AddService();
services.AddMapper();
services.AddHttpClient();

// Регистрация миддлваров.
WebApplication app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();

app.UseGrpcEndpoints();

app.Run();