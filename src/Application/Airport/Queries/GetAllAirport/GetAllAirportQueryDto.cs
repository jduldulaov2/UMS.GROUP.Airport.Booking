using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAllAirport;
public class GetAllAirportQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? AirportName { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Region { get; set; }

    public string? ZipCode { get; set; }

    public int? CountryId { get; set; }

    public string? CountryName { get; set; }

    public bool? IsActive { get; set; }
}
