using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Booking.Command.CreateBooking;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(v => v.FlightDate).NotEmpty().WithMessage("FlightDate is required.");
        RuleFor(v => v.FirstName).NotEmpty().WithMessage("FirstName is required.");
        RuleFor(v => v.LastName).NotEmpty().WithMessage("LastName is required.");
        RuleFor(v => v.MiddleName).NotEmpty().WithMessage("MiddleName is required.");
    }
}
