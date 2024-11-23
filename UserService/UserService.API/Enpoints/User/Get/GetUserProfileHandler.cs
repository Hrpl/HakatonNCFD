using UserService.Domain.Commons.Requests;
using UserService.Infrastructure.Services.Interfaces;

using FastEndpoints;
using UserService.Domain.Commons.Response;

namespace UserService.API.Enpoints.User.Get
{
    public class GetUserProfileHandler : Endpoint<GetUserProfileRequest, GetUserProfileResponse>
    {
        private readonly IUserProfileService _userProfileService;
        private readonly IJwtHelper _jwtHelper;
        public GetUserProfileHandler(IUserProfileService userProfileService, IJwtHelper jwtHelper)
        {
            _userProfileService = userProfileService;
            _jwtHelper = jwtHelper;
        }

        public override void Configure()
        {
            Post("get/userProfile");
            AllowAnonymous();
            Group<UserEndpointGroup>();
            Summary(sum =>
            {
                sum.Summary = "Получение профиля пользователя";
                sum.Description = "Эндпоинт для получение профиля пользователя";
            });
        }

        public override async Task HandleAsync(GetUserProfileRequest req, CancellationToken ct)
        {
            var id = await _jwtHelper.DecodJwt(req.JWT);
            var response = await _userProfileService.GetUserProfileAsync(id);

            await SendOkAsync( response);
        }
    }
}
