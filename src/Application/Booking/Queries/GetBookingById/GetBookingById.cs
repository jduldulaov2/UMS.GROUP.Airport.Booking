using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingById;

public record GetBookingByIdQuery : IRequest<List<GetBookingByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetBookingByIdQuery, List<GetBookingByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetBookingByIdQueryDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        return await (from booking in _context.PassengerBooking
                      join flight in _context.Flight on booking.FlightId equals flight.Id
                      join airport in _context.Airport on flight.AirportId equals airport.Id
                      join plane in _context.Plane on flight.PlaneId equals plane.Id
                      where booking.UniqueId == request.UniqueId
                      select new GetBookingByIdQueryDto
                      {
                          Id = booking.Id,
                          FlightCode = flight.FlightCode,
                          FlightDate = booking.FlightDate.ToString(),
                          PlaneName = plane.AirlineName,
                          AirportName = airport.AirportName,
                          FirstName = booking.FirstName,
                          LastName = booking.LastName,
                          MiddleName = booking.MiddleName,
                          Street = booking.Street,
                          City = booking.City,
                          ContactNumber = booking.ContactNumber,
                          Region = booking.Region,
                          Province = booking.Province,
                          Destination = booking.Destination,
                          Origin = booking.Origin,
                          FlightId = booking.FlightId,
                          UniqueId = booking.UniqueId,
                          ZipCode = booking.ZipCode,
                          Avatar = "GG"
                      }).ToListAsync();
    }
}
