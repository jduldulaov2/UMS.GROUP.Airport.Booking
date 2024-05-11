using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Command.UpdateAirport;

public class UpdateAirportCommandValidator : AbstractValidator<UpdateAirportCommand>
{
    public UpdateAirportCommandValidator()
    {
        RuleFor(v => v.AirportName)
            .NotEmpty()
            .WithMessage("AirportName is required.");
        RuleFor(v => v.CountryId)
            .NotEmpty()
            .WithMessage("Country is required.");
    }
}
