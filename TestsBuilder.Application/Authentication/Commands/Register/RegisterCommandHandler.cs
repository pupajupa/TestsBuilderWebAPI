using ErrorOr;
using MediatR;
using TestsBuilder.Application.Authentication.Common;
using TestsBuilder.Application.Common.Interfaces.Authentication;
using TestsBuilder.Application.Common.Interfaces.Persistence;
using TestsBuilder.Domain.Common.Errors;
using TestsBuilder.Domain.Entities;

namespace TestsBuilder.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler:
        IRequestHandler<RegisterCommand,ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command,CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Validate the user doesn`t exist
            if (_userRepository.GetUserByEmail(command.Email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }

            //2. Create user (generate unique ID) & Persist to DB
            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                Password = command.Password
            };

            _userRepository.Add(user);
            //3. Create JWT token

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
