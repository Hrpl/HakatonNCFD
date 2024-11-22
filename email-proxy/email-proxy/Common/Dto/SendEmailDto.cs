using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace email_proxy.Common.Dto;

public class SendEmailDto
{
    public List<ToPersonDto> ToPerson { get; set; } = new();
    public string Subject { get; set; }
    public string MessageBody { get; set; }
    public IFormFileCollection? Files { get; set; }
}