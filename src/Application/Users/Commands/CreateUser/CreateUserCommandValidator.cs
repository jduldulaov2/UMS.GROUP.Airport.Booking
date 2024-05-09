using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty();

        RuleFor(v => v.Password)
            .NotEmpty();

        RuleFor(v => v.LastName)
            .NotEmpty();

        RuleFor(v => v.FirstName)
            .NotEmpty();

        RuleFor(v => v.EmailAddress)
            .NotEmpty();
    }
}
