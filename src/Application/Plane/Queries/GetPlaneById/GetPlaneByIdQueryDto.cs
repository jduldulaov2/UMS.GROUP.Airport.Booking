using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneById;

public class GetPlaneByIdQueryDto
{
    public int? Id { get; set; }

    public string? AirlineName { get; set; }

    public string? Code { get; set; }

    public string? Model { get; set; }

    public string? UniqueId { get; set; }

    public bool? IsActive { get; set; }
}
