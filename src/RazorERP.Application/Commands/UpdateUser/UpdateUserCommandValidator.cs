using FluentValidation;
using RazorERP.Application.Commands.CreateUser;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public UpdateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Role).NotNull().IsInEnum();
        }

    }
}
