using email_proxy.Common.Dto;
using EmailProxy;
using Mapster;

namespace email_proxy.Common.MapperProfile;

public class EmailProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SendEmailRequest, SendEmailDto>()
            .Map(dest => dest.ToPerson, src => src.Person);
        config.NewConfig<Person, ToPersonDto>();
    }
}