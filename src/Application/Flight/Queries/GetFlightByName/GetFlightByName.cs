using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightByName;

public record GetFlightByNameQuery : IRequest<List<GetFlightNameQueryDto>>
{
    public string? FlightCode { get; set; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetFlightByNameQuery, List<GetFlightNameQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetFlightNameQueryDto>> Handle(GetFlightByNameQuery request, CancellationToken cancellationToken)
    {
        return await (from flight in _context.Flight
                      join airport in _context.Airport on flight.AirportId equals airport.Id
                      join plane in _context.Plane on flight.PlaneId equals plane.Id
                      where EF.Functions.Like(flight.FlightCode, "%" + request.FlightCode + "%")
                      select new GetFlightNameQueryDto
                      {
                          Id = flight.Id,
                          AirportId = airport.Id,
                          PlaneId = plane.Id,
                          AirportName = airport.AirportName,
                          FlightCode = flight.FlightCode,
                          PlaneName = plane.AirlineName,
                          UniqueId = flight.UniqueId,
                          IsActive = flight.IsActive == null ? true : flight.IsActive
                      }).ToListAsync();
    }
}
