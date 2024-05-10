using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class Flight : BaseAuditableEntity
{
    public string? FlightCode { get; set; }

    public int? AirportId { get; set; }

    public int? PlaneId { get; set; }
}
