using Google.Protobuf.Collections;
using Mapster;

namespace email_proxy.Common.MapperProfile;

public class MainProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.Default.PreserveReference(true);
        
        // Конфигурация для мапа в RepeatedField (т.к. он без сеттера)
        config.Default.UseDestinationValue(
            member => member.SetterModifier == AccessModifier.None &&
                      member.Type.IsGenericType &&
                      member.Type.GetGenericTypeDefinition() == typeof(RepeatedField<>));
    }
}