using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Command.CreateAirport;

public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
{
    public CreateAirportCommandValidator()
    {
        RuleFor(v => v.AirportName).NotEmpty().WithMessage("AirportName is required.");
        RuleFor(v => v.CountryId).NotEmpty().WithMessage("Country is required.");
    }
}
