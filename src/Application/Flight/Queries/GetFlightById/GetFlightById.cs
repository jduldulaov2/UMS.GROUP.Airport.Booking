using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneById;
using UMS.GROUP.Airport.Booking.Domain.Entities;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightById;

public record GetFlightByIdQuery : IRequest<Result<GetFlightByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetFlightByIdQuery, Result<GetFlightByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetFlightByIdQueryDto>> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Flight.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetFlightByIdQueryDto
                {
                    Id = result.Id,
                    AirportId = result.AirportId,
                    PlaneId = result.PlaneId,
                    FlightCode = result.FlightCode,
                    UniqueId = result.UniqueId,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetFlightByIdQueryDto
            {

            },
            Message = "Failed - no record found.",
            ResultType = ResultType.Error,
        };
    }
}
