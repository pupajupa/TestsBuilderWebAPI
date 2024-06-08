using ErrorOr;
using MediatR;
using TestsBuilder.Application.Authentication.Common;
using TestsBuilder.Application.Authentication.Queries.Login;
using TestsBuilder.Application.Common.Interfaces.Authentication;
using TestsBuilder.Application.Common.Interfaces.Persistence;
using TestsBuilder.Domain.Common.Errors;
using TestsBuilder.Domain.User;

namespace TestsBuilder.Application.Authentication.Commands.Login
{
    public class LoginQueryHandler :
        IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
    {
        private readonly IUserRepository _userRepository;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query,CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            //1. Validate the user exists
            if (_userRepository.GetUserByEmail(query.Email) is not User user)
            {
                return Errors.Authentication.InvalidCredential;
                //throw new Exception("User with given email does not exist.");
            }
            //2. Validate the password is correct
            if (user.Password != query.Password)
            {
                return Errors.Authentication.InvalidCredential;
            }
            //3. Create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}
