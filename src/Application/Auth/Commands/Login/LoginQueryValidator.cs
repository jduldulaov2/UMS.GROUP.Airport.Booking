using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Auth.Commands.Login;

public class LoginQueryValidator : AbstractValidator<LoginCommand>
{
    public LoginQueryValidator()
    {
        RuleFor(v => v.UserName)
            .NotEmpty();

        RuleFor(v => v.Password)
           .NotEmpty();
    }
}
