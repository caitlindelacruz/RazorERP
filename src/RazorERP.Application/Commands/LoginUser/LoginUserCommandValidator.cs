using FluentValidation;
using RazorERP.Application.Interfaces;

namespace RazorERP.Application.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator(IUserRepository userRepository)
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("User email is required.")
                .EmailAddress().WithMessage("Should be in email format.");
            RuleFor(x => x.Password).NotNull().NotEmpty();
        }

    }
}