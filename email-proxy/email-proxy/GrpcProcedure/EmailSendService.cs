using System.Threading.Tasks;
using email_proxy.Common.Dto;
using email_proxy.Service.Interface;
using EmailProxy;
using Grpc.Core;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace email_proxy.GrpcProcedure;

public class EmailSendService : EmailProxy.EmailSendService.EmailSendServiceBase
{
    private readonly IEmailService _emailService;
    private readonly IMapper _mapper;

    public EmailSendService(IEmailService emailService, IMapper mapper)
    {
        _emailService = emailService;
        _mapper = mapper;
    }

    public override async Task<SendEmailResponse> SendEmail(SendEmailRequest request, ServerCallContext context)
    {
        var email = _mapper.Map<SendEmailDto>(request);

        var result = await _emailService.SendEmail(email, context.CancellationToken);

        var response = _mapper.Map<SendEmailResponse>(result);

        return response;
    }
}