using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetAllBooking;
public class GetAllBookingQueryDto
{

    public int? Id { get; set; }

    public int? FlightId { get; set; }

    public string? FlightCode { get; set; }

    public string? FlightDate { get; set; }

    public string? AirportName { get; set; }

    public string? PlaneName { get; set; }

    public string? Origin { get; set; }

    public string? Destination { get; set; }

    public string? Avatar { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Region { get; set; }

    public string? ZipCode { get; set; }

    public string? ContactNumber { get; set; }

    public string? UniqueId { get; set; }

    public string? AvatarColor { get; set; }
}
