using System.Threading;
using System.Threading.Tasks;
using email_proxy.Common.Dto;

namespace email_proxy.Service.Interface;

public interface IEmailService
{
    Task<BaseResponseMessage> SendEmail(SendEmailDto data, CancellationToken ct = default);
}