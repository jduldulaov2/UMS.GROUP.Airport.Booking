using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class PassengerBooking : BaseAuditableEntity
{
    public int? FlightId { get; set; }
    public DateTime? FlightDate { get; set; }
    public string? Origin { get; set; }
    public string? Destination { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? Province { get; set; }
    public string? Region { get; set; }
    public string? ZipCode { get; set; }
    public string? ContactNumber { get; set; }
    public string? AvatarColor { get; set; }
}
