using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAirportById;

public class GetAirportByIdQueryValidator : AbstractValidator<GetAirportByIdQuery>
{
    public GetAirportByIdQueryValidator()
    {
        RuleFor(x => x.UniqueId)
            .NotEmpty().WithMessage("UniqueId is required.");
    }
}
