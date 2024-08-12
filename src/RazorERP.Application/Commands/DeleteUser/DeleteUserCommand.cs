using MediatR;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IPasswordService _passwordService;

            public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork,
                IPasswordService passwordService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _passwordService = passwordService;
            }

            public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(command.Id);
                if (user == null) return false;

                await _userRepository.DeleteAsync(command.Id);
                _unitOfWork.Commit();

                return true;
            }
        }
    }
}


