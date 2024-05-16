using ErrorOr;
using MediatR;
using TestsBuilder.Application.Authentication.Common;

namespace TestsBuilder.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
