using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.SendEmailAfterRegistration;

public class CreateEmailRegistrationCommandValidator : AbstractValidator<CreateEmailAfterRegistrationCommand>
{
    public CreateEmailRegistrationCommandValidator()
    {
        RuleFor(v => v.EmailAddress)
            .NotEmpty();

        RuleFor(v => v.UserName)
            .NotEmpty();

        RuleFor(v => v.Password)
            .NotEmpty();

        RuleFor(v => v.FullName)
            .NotEmpty();
    }
}
