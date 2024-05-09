using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;

namespace UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.CreateSystemEnvironment;

public class CreateSystemEnvironmentCommandValidator : AbstractValidator<CreateSystemEnvironmentCommand>
{
    public CreateSystemEnvironmentCommandValidator()
    {
        RuleFor(v => v.SystemName)
            .NotEmpty();
    }
}
