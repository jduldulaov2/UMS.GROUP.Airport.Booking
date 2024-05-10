using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GelAllAirportByCountry;
public class GetAllAirportByCountryQueryValidator : AbstractValidator<GelAllAirportByCountryQuery>
{
    public GetAllAirportByCountryQueryValidator()
    {
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("CountryId is required.");
    }
}
