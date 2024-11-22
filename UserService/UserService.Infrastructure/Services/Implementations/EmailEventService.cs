using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Services.Implementations;

public class EmailEventService : IEmailEventService
{
    private readonly QueryFactory _query;

    public EmailEventService(IDbConnectionManager connectionManager)
    {
        _query = connectionManager.PostgresQueryFactory;
    }

    public async Task CreateEmailEventAsync(EmailEventModel eventModel)
    {
        var query = _query.Query("EmailEvents")
            .AsInsert(eventModel);

        await _query.ExecuteAsync(query);
    }

    public async Task DeleteEmailEventAsync(int code)
    {
        var query = _query.Query("EmailEvents")
            .Where("Code", code)
            .Delete();
    }

    public async Task<int> GetEmailEventCodeAsync(string email)
    {
        var query = _query.Query("EmailEvents")
            .Select("Code")
            .Where("Email", email);
            
        var result = await _query.FirstAsync<int>(query);

        return result;
    }
}
