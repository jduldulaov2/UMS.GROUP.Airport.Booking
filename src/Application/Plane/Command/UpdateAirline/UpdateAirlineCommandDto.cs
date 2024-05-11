using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Command.UpdateAirline;
public class UpdateAirlineCommandDto
{
    public string? Id { get; set; }

    public DateTime UpdatedDate { get; set; }
}
