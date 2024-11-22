using PerfumeShop.Infrastructure.Services.Implementations;
using PerfumeShop.Infrastructure.Services.Interfaces;
using SportEvents.Infrastructure.Services.Implementations;
using SportEvents.Infrastructure.Services.Interfaces;

namespace PerfumeShop.API.Extensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddRegisterService();
    }
    public static void AddRegisterService(this IServiceCollection services)
    {
        services.AddScoped<IDbConnectionManager, DbConnectionManager>();
        services.AddScoped<ISportEventService, SportEventService>();
        services.AddScoped<IFavouritesEventService, FavouritesEventService>();
    }
}
