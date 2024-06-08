using TestsBuilder.Domain.User;

namespace TestsBuilder.Application.Authentication.Common
{
    public record AuthenticationResult(User User,string Token);
}
