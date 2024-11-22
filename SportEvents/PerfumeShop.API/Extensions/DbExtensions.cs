using Microsoft.EntityFrameworkCore;
using PerfumeShop.Infrastructure.Context;

namespace PerfumeShop.API.Extensions;

public static class DbExtensions
{
    public static void AddDataBase(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("DbConnection"),
                o => o
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
    }
}
