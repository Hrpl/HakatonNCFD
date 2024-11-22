using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services.Interfaces;

public interface IEmailEventService
{
    public Task CreateEmailEventAsync(EmailEventModel eventModel);
    public Task<int> GetEmailEventCodeAsync(string email);
    public Task DeleteEmailEventAsync(int code);
}
