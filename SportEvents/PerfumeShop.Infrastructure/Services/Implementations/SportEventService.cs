using PerfumeShop.Infrastructure.Services.Interfaces;
using SportEvents.Domain.Common.Request;
using SportEvents.Domain.Common.Response;
using SportEvents.Domain.Models;
using SportEvents.Infrastructure.Services.Interfaces;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvents.Infrastructure.Services.Implementations;

public class SportEventService : ISportEventService
{
    private readonly QueryFactory _queryFactory;

    public SportEventService(IDbConnectionManager connectionManager)
    {
        _queryFactory = connectionManager.PostgresQueryFactory;
    }

    public async Task<List<SportEventResponse>> GetAllSportEventsAsync(PaginateRequest request)
    {
        var query = _queryFactory.Query("SportEvents as se")
            .Join("TypeSports as ts", "ts.Id", "se.TypeId")
            .Join("Compositions as c", "c.Id", "se.CompositionId")
            .Select("c.Name as Composition",
            "ts.Name as TypeEvent",
            "se.EventName",
            "se.EventDescription",
            "se.StartDate",
            "se.EndDate",
            "se.Country",
            "se.Address",
            "se.Participants")
            .Limit(request.Count)
            .Offset(request.Count  * (request.Page - 1));

        var result = await _queryFactory.GetAsync<SportEventResponse>(query);

        return result.ToList();
    }
}
