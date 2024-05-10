using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightById;

public record GetFlightByIdQuery : IRequest<List<GetFlightByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetFlightByIdQuery, List<GetFlightByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetFlightByIdQueryDto>> Handle(GetFlightByIdQuery request, CancellationToken cancellationToken)
    {
        return await (from flight in _context.Flight
                      join airport in _context.Airport on flight.AirportId equals airport.Id
                      join plane in _context.Plane on flight.PlaneId equals plane.Id
                      where flight.UniqueId == request.UniqueId
                      select new GetFlightByIdQueryDto
                      {
                          Id = flight.Id,
                          AirportId = airport.Id,
                          PlaneId = plane.Id,
                          AirportName = airport.AirportName,
                          FlightCode = flight.FlightCode,
                          PlaneName = plane.AirlineName,
                          UniqueId = flight.UniqueId
                      }).ToListAsync();
    }
}
