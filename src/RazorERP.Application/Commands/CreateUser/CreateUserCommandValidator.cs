using FluentValidation;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Password).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("User email is required.")
                .EmailAddress().WithMessage("Should be in email format.");
            RuleFor(x => x.Role) .NotNull().IsInEnum();
        }

    }
}
