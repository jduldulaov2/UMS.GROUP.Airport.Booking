using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.UpdateSystemEnvironment;

public class UpdateSystemEnvironmentCommandValidator : AbstractValidator<UpdateSystemEnvironmentCommand>
{
    public UpdateSystemEnvironmentCommandValidator()
    {
        RuleFor(v => v.SystemName)
            .NotEmpty();

        RuleFor(v => v.EmailServer)
            .NotEmpty();

        RuleFor(v => v.EmailAddress)
            .NotEmpty();

        RuleFor(v => v.EmailPassword)
            .NotEmpty();

        RuleFor(v => v.SMTPPort)
            .NotEmpty();

        RuleFor(v => v.UserRegistrationHTMLSubject)
            .NotEmpty();

        RuleFor(v => v.UserRegistrationHTMLTemplate)
            .NotEmpty();
    }
}
