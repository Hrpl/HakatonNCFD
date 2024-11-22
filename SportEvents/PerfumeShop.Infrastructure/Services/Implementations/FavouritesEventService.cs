using PerfumeShop.Infrastructure.Services.Interfaces;
using SportEvents.Domain.Models;
using SportEvents.Infrastructure.Services.Interfaces;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Infrastructure.Services.Implementations;

public class FavouritesEventService : IFavouritesEventService
{
    private readonly QueryFactory _queryFactory;

    public FavouritesEventService(IDbConnectionManager connectionManager)
    {
        _queryFactory = connectionManager.PostgresQueryFactory;
    }
    public Task CreateFavouritesEvent(FavouritesEventModel model)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FavouritesEventModel>> GetAnyFavouritesEvent(int id)
    {
        throw new NotImplementedException();
    }
}
