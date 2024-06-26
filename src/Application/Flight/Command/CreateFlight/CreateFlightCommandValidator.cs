﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Command.CreateFlight;

public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        RuleFor(v => v.FlightCode)
            .NotEmpty()
            .WithMessage("FlightCode is required.");
        RuleFor(v => v.AirportId)
            .NotEmpty()
            .WithMessage("Airport is required.");
        RuleFor(v => v.PlaneId)
            .NotEmpty()
            .WithMessage("Airline is required.");
    }
}
