using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Command.UpdateFlight;
public class UpdateFlightCommandDto
{
    public string? Id { get; set; }

    public DateTime UpdatedDate { get; set; }
}
