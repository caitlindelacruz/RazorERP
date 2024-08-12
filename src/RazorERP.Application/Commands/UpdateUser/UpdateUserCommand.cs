using MediatR;
using RazorERP.Application.Enums;
using RazorERP.Application.Interfaces;
using RazorERP.Domain.Entities;

namespace RazorERP.Application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public Role Role { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPasswordService _passwordService;

            public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
                IPasswordService passwordService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _passwordService = passwordService;
            }

            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    Name = command.Name,
                    Role = command.Role.ToString()
                };

                await _userRepository.UpdateAsync(user);
                _unitOfWork.Commit();

                return user.Id;
            }
        }
    }
}

