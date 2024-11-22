using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using email_proxy.Common.Dto;
using email_proxy.Common.Options;
using email_proxy.Service.Interface;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace email_proxy.Service.Implementation;

public class EmailService : IEmailService
{
    private readonly SmtpClientOptions _smtpClientOptions;

    public EmailService(IOptions<SmtpClientOptions> smtpClientOptions)
    {
        _smtpClientOptions = smtpClientOptions.Value;
    }

    public async Task<BaseResponseMessage> SendEmail(SendEmailDto data, CancellationToken ct = default)
    {
        if (String.IsNullOrEmpty(_smtpClientOptions.Host) || String.IsNullOrEmpty(_smtpClientOptions.Port.ToString()) ||
            String.IsNullOrEmpty(_smtpClientOptions.Email) || String.IsNullOrEmpty(_smtpClientOptions.Password))
            return new BaseResponseMessage { StatusCode = 400, Description = "Settings email SmtpClient error!" };
        var emailMessage = new MimeMessage
        {
            Subject = data.Subject,
        };
        emailMessage.From.Add(new MailboxAddress(_smtpClientOptions.Name, _smtpClientOptions.Email));
        foreach (var person in data.ToPerson)
        {
            emailMessage.To.Add(new MailboxAddress(person.Name, person.Email));
        }

        var builder = new BodyBuilder
        {
            HtmlBody = data.MessageBody
        };

        var a = new List<Stream>();
        if (data.Files != null)
        {
            foreach (var file in data.Files)
            {
                var fileStream = file.OpenReadStream();
                a.Add(fileStream);
                await builder.Attachments.AddAsync(file.FileName, fileStream, ct);
            }
        }

        emailMessage.Body = builder.ToMessageBody();
        try
        {
            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_smtpClientOptions.Host, _smtpClientOptions.Port, SecureSocketOptions.Auto, ct);
            await smtpClient.AuthenticateAsync(_smtpClientOptions.Email, _smtpClientOptions.Password, ct);
            await smtpClient.SendAsync(emailMessage, ct);
            await smtpClient.DisconnectAsync(true, ct);
            return new BaseResponseMessage { StatusCode = 200, Description = "Success" };
        }
        catch (Exception)
        {
            return new BaseResponseMessage { StatusCode = 400, Description = "Send email error!" };
        }
        finally
        {
            if (a.Any())
            {
                foreach (var stream in a)
                {
                    stream.Close();
                }
            }
        }
    }
}