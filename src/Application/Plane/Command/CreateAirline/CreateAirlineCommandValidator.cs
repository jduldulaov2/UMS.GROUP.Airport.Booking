using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Command.CreateAirline;

public class CreateAirlineCommandValidator : AbstractValidator<CreateAirlineCommand>
{
    public CreateAirlineCommandValidator()
    {
        RuleFor(v => v.AirlineName)
            .NotEmpty()
            .WithMessage("AirlineName is required.");
        RuleFor(v => v.Code)
            .NotEmpty()
            .WithMessage("Code is required.");
        RuleFor(v => v.Model)
            .NotEmpty()
            .WithMessage("Model is required.");
    }
}
