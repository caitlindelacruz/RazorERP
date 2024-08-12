using MediatR;
using RazorERP.Application.Enums;
using RazorERP.Application.Interfaces;
using RazorERP.Domain.Entities;

namespace RazorERP.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPasswordService _passwordService;

            public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
                IPasswordService passwordService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _passwordService = passwordService;
            }

            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Email = command.Email,
                    Name = command.Name,
                    PasswordHash = _passwordService.HashPassword(command.Password),
                    Role = command.Role.ToString()
                };

                await _userRepository.AddAsync(user);
                _unitOfWork.Commit();

                user = await _userRepository.GetByEmailAsync(command.Email);

                return user.Id;
            }
        }
    }
}
