using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Commons.Response;
using UserService.Domain.Models;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Services.Implementations;

public class UserProfileService : IUserProfileService
{
    private readonly QueryFactory _query;
    public UserProfileService(IDbConnectionManager _connectionManager)
    {
        _query = _connectionManager.PostgresQueryFactory;
    }

    public async Task CreateUserProfileAsync(UserProfileModel model)
    {
        var query = _query.Query("UserProfiles")
            .AsInsert(model);

        await _query.ExecuteAsync(query);
    }

    public async Task<GetUserProfileResponse> GetUserProfileAsync(int id)
    {
        var query = _query.Query("UserProfiles")
            .Where("AppUserId", id)
            .Select("AppUserId",
            "Name",
            "Surname",
            "Patronymic",
            "Age",
            "Male",
            "City");

        var result = await _query.FirstAsync<GetUserProfileResponse>(query);
        if (result is null) throw new Exception("Профиль не найден.");
        return result;
    }

    public async Task<int> UpdateUserProfileAsync(UpdateUserProfileRequest model)
    {
        int affected = _query.Query("UserProfiles").Where("AppUserId", model.AppUserId).Update(model);
        return affected;
    }
}
