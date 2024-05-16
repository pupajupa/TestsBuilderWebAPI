using Mapster;
using TestsBuilder.Application.Authentication.Commands.Register;
using TestsBuilder.Application.Authentication.Common;
using TestsBuilder.Application.Authentication.Queries.Login;
using TestsBuilder.Contracts.Authentication;

namespace TestsBuilder.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            
            config.NewConfig<LoginRequest, LoginQuery>();

            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
