using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Command.CreateFlight;
public class CreateFlightCommandDto
{
    public string? Id { get; set; }

    public DateTime CreatedDate { get; set; }
}
