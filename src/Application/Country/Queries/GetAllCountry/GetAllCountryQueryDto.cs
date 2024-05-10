using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Country.Queries.GetAllCountry;
public class GetAllCountryQueryDto
{
    public int? Id { get; set; }

    public string? CountryName { get; set; }

    public string? CountryCode { get; set; }

    public string? Description { get; set; }
}
