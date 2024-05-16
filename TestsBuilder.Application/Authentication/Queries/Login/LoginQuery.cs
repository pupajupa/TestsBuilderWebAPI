using ErrorOr;
using MediatR;
using TestsBuilder.Application.Authentication.Common;

namespace TestsBuilder.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
