using MediatR;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, string>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPasswordService _passwordService;
            private readonly IJwtTokenGenerator _jwtTokenGenerator;

            public LoginUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
                IPasswordService passwordService, IJwtTokenGenerator jwtTokenGenerator)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _passwordService = passwordService;
                _jwtTokenGenerator=jwtTokenGenerator;
            }

            public async Task<string?> Handle(LoginUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByEmailAsync(command.Email);

                if(user == null)
                {
                    return null;
                }

                if (!_passwordService.VerifyPassword(user.PasswordHash, command.Password))
                {
                    return null;
                }

                // Create token
                var token = _jwtTokenGenerator.GenerateToken(user);

                return token;
            }
        }
    }
}
