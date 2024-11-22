using UserService.Domain.Commons.DTO;

namespace UserService.API.Services.Interfaces;

public interface IEmailService
{
    public Task ConfirmEmail(PersonDto person, CancellationToken ct);
}
