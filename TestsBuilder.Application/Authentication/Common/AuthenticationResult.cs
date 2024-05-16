using TestsBuilder.Domain.Entities;

namespace TestsBuilder.Application.Authentication.Common
{
    public record AuthenticationResult(User User,string Token);
}
