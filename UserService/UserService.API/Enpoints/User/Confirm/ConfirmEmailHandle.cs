using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using System.Data;
using UserService.API.Enpoints.Auth;
using UserService.API.Enpoints.User;
using UserService.API.Services.Interfaces;
using UserService.Domain.Commons.DTO;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Entities;
using UserService.Infrastructure.Services.Implementations;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Enpoints.User.Confirm;

public class ConfirmEmailHandle : Endpoint<ConfirmEmailRequest>
{
    private readonly IEmailEventService _emailEventService;
    private readonly UserManager<AppUser> _userManager;
    public ConfirmEmailHandle(IEmailEventService emailEventService, UserManager<AppUser> userManager)
    {
        _emailEventService = emailEventService;
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("confirm/email");
        AllowAnonymous();
        Group<UserEndpointGroup>();
        Summary(sum =>
        {
            sum.Summary = "Подтверждение почты пользователя";
            sum.Description = "Эндпоинт для подтверждение почты пользователя";
        });
    }

    public override async Task HandleAsync(ConfirmEmailRequest req, CancellationToken ct)
    {
        var code = await _emailEventService.GetEmailEventCodeAsync(req.Email);

        if (code == req.Code)
        {
            var user = await _userManager.FindByEmailAsync(req.Email);
            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);
            await _emailEventService.DeleteEmailEventAsync(code);
        }
        else throw new Exception("Неверный код!");
    }
}
