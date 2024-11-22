namespace UserService.API.Enpoints.User.Update;
using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Entities;
using UserService.Infrastructure.Services.Interfaces;

public class UpdateUserProfile : Endpoint<UpdateUserProfileRequest>
{
    private readonly IUserProfileService _userProfileService;
    public UpdateUserProfile(IUserProfileService userProfileService)
    {
        _userProfileService = userProfileService;
    }

    public override void Configure()
    {
        Post("update/userProfile");
        AllowAnonymous();
        Group<UserEndpointGroup>();
        Summary(sum =>
        {
            sum.Summary = "Обновление профиля пользователя";
            sum.Description = "Эндпоинт для обновление профиля пользователя";
        });
    }

    public override async Task HandleAsync(UpdateUserProfileRequest req, CancellationToken ct)
    {
        await _userProfileService.UpdateUserProfileAsync(req);
    }
}
