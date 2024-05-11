using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Command.UpdateAirport;
public class UpdateAirportCommandDto
{
    public string? Id { get; set; }

    public DateTime UpdatedDate { get; set; }
}
