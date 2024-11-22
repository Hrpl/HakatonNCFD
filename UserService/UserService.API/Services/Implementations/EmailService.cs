using Microsoft.Extensions.Options;
using UserService.API.Services.Interfaces;
using EmailProxy;
using UserService.Domain.Commons.DTO;
using UserService.Domain.Commons.Template;
using System;
using UserService.Infrastructure.Services.Interfaces;
using UserService.Domain.Models;

namespace UserService.API.Services.Implementations;

public class EmailService : IEmailService
{
    private readonly EmailSendService.EmailSendServiceClient _sendServiceClient;
    private readonly IEmailEventService _emailEventService;
    public EmailService(EmailSendService.EmailSendServiceClient sendServiceClient, IEmailEventService emailEventService)
    {
        _sendServiceClient = sendServiceClient;
        _emailEventService = emailEventService; 
    }

    public async Task ConfirmEmail(PersonDto person, CancellationToken ct)
    {
        var file = EmailTemplates.RegistrationEmailTemplate;
        Random random = new Random();
        var code = random.Next(100000, 1000000);
        file = file.Replace("@fullname", person.FullName);
        file = file.Replace("@code", $"{code}");

        var model = new EmailEventModel { Email = person.Email, Code = code };
        await _emailEventService.CreateEmailEventAsync(model);

        var requestPerson = new Person { Email = person.Email, Name = person.FullName };

        var request = new SendEmailRequest()
        {
            MessageBody = file,
            Person = { requestPerson },
            Subject = "Подтверждение почты"
        };

        await _sendServiceClient.SendEmailAsync(request, cancellationToken: ct);
    }
}
