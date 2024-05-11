using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightByName;
public class GetFlightNameQueryDto
{
    public int? Id { get; set; }

    public string? FlightCode { get; set; }

    public int? AirportId { get; set; }

    public int? PlaneId { get; set; }

    public string? AirportName { get; set; }

    public string? PlaneName { get; set; }

    public string? UniqueId { get; set; }

    public bool? IsActive { get; set; }
}
