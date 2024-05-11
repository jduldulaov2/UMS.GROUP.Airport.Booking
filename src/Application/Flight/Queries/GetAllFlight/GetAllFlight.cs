using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetAllFlight;

public record GetAllFlightQuery : IRequest<List<GetAllFlightQueryDto>>
{

}

public class GetMediaDetailQueryHandler : IRequestHandler<GetAllFlightQuery, List<GetAllFlightQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllFlightQueryDto>> Handle(GetAllFlightQuery request, CancellationToken cancellationToken)
    {
        return await (from flight in _context.Flight
                      join airport in _context.Airport on flight.AirportId equals airport.Id
                      join plane in _context.Plane on flight.PlaneId equals plane.Id
                      select new GetAllFlightQueryDto
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
