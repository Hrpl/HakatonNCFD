using PerfumeShop.Infrastructure.Services.Interfaces;
using SportEvents.Domain.Common.Response;
using SportEvents.Domain.Entities;
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
    public async Task CreateFavouritesEvent(FavouritesEventModel model)
    {
        model.CreatedAt = DateTime.Now;
        model.UpdatedAt = DateTime.Now;
        model.IsDeleted = false;
        var query = _queryFactory.Query("FavouritesEvents")
            .AsInsert(model);

        await _queryFactory.ExecuteAsync(query);
    }

    public async Task<IEnumerable<SportEventResponse>> GetAnyFavouritesEvent(int id)
    {
        var query = _queryFactory.Query("FavouritesEvents as fe")
            .Where("fe.UserId", "=", id)
            .Join("SportEvents as se", "se.Id", "fe.SportEventId")
            .Join("TypeSports as ts", "ts.Id", "se.TypeId")
            .Join("Compositions as c", "c.Id", "se.CompositionId")
            .Select("c.Name as Composition",
            "ts.Name as TypeEvent",
            "se.Id as Id",
            "se.EventName as EventName",
            "se.EventDescription as EventDescription",
            "se.StartDate as StartDate",
            "se.EndDate as EndDate",
            "se.Country as Country",
            "se.Address as Address",
            "se.Participants as Participants");

        var result = await _queryFactory.GetAsync<SportEventResponse>(query);

        return result;
    }
}
