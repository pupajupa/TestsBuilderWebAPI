using Mapster;
using TestsBuilder.Application.Authentication.Commands.Register;
using TestsBuilder.Application.Authentication.Common;
using TestsBuilder.Application.Authentication.Queries.Login;
using TestsBuilder.Contracts.Authentication;
using TestsBuilder.Domain.User.ValueObjects;

namespace TestsBuilder.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User)
                .Map(dest => dest.Id, src => UserId.Create(src.User.Id.Value));
        }
    }
}
