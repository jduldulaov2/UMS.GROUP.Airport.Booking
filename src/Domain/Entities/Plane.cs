using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class Plane : BaseAuditableEntity
{
    public string? AirlineName { get; set; }

    public string? Code { get; set; }

    public string? Model { get; set; }
}
