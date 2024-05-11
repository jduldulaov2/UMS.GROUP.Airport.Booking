using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Booking.Command.UpdateBooking;

public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommand>
{
    public UpdateBookingCommandValidator()
    {
        RuleFor(v => v.FlightDate)
            .NotEmpty()
            .WithMessage("FlightDate is required.");
        RuleFor(v => v.FirstName)
            .NotEmpty()
            .WithMessage("FirstName is required.");
        RuleFor(v => v.LastName)
            .NotEmpty()
            .WithMessage("LastName is required.");
        RuleFor(v => v.MiddleName)
            .NotEmpty()
            .WithMessage("MiddleName is required.");
    }
}
