using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using System.Data;
using UserService.API.Enpoints.Auth;
using UserService.API.Enpoints.User;
using UserService.API.Services.Interfaces;
using UserService.Domain.Commons.DTO;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Entities;
using UserService.Domain.Models;
using UserService.Infrastructure.Services.Implementations;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Enpoints.User.Create;

public class CreateUserHandle : Endpoint<CreateUserRequest>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserProfileService _userService;
    private readonly IEmailService _emailService;
    public CreateUserHandle(UserManager<AppUser> userManager, IUserProfileService userService, IEmailService emailService)
    {
        _userManager = userManager;
        _userService = userService;
        _emailService = emailService;
    }

    public override void Configure()
    {
        Post("create");
        AllowAnonymous();
        Group<UserEndpointGroup>();
        Summary(sum =>
        {
            sum.Summary = "Создание нового пользователя";
            sum.Description = "Эндпоинт для создания нового пользователя";
        });
    }

    public override async Task HandleAsync(CreateUserRequest req, CancellationToken ct)
    {
        if (req.Email == "") throw new Exception("Поле Email не заполнено");
        if (req.UserName.Length < 2) throw new Exception("Необходимо заполнить ФИО");

        var findEmail = await _userManager.FindByEmailAsync(req.Email);

        if (findEmail != null) throw new Exception("Пользователь с таким email уже существует");

        var user = new AppUser { Email = req.Email, UserName = req.Email.Split("@")[0] };
        
        var res = await _userManager.CreateAsync(user, req.Password);

        var createdUser = await _userManager.FindByEmailAsync(req.Email);

        var splitUserName = req.UserName.Split(" ");

        var userProfile = new UserProfileModel { AppUserId = createdUser.Id };

        if (splitUserName.Length > 0) userProfile.Surname = splitUserName[0];
        
        if (splitUserName.Length > 1) userProfile.Name = splitUserName[1];
        
        if (splitUserName.Length > 2) userProfile.Patronymic = splitUserName[2];
        
        await _userService.CreateUserProfileAsync(userProfile);

        if (res.Errors.ToList().Count > 0) throw new Exception($"{res.Errors.First().Description}");
        else
        {
            try
            {
                var person = new PersonDto() { Email = req.Email, FullName = req.UserName };
                await _emailService.ConfirmEmail(person, ct);
            }
            catch (Exception ex) 
            {
                throw new Exception("Ошибка отправки сообщения пользователю.");
            }
            await SendOkAsync(req.Email);
        }
    }
}
