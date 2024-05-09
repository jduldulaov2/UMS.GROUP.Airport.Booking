using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.UpdateSystemEnvironment;

public class UpdateSystemEnvironmentDto
{
    public string? Id { get; set; }

    public DateTime UpdatedDate { get; set; }
}
