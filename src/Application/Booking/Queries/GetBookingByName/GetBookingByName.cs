using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingByName;

public record GetBookingByNameQuery : IRequest<List<GetBookingByNameQueryDto>>
{
    public string? LastName { get; set; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetBookingByNameQuery, List<GetBookingByNameQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetBookingByNameQueryDto>> Handle(GetBookingByNameQuery request, CancellationToken cancellationToken)
    {
        return await (from booking in _context.PassengerBooking
                      join flight in _context.Flight on booking.FlightId equals flight.Id
                      join airport in _context.Airport on flight.AirportId equals airport.Id
                      join plane in _context.Plane on flight.PlaneId equals plane.Id
                      where EF.Functions.Like(booking.LastName, "%" + request.LastName + "%")
                      select new GetBookingByNameQueryDto
                      {
                          Id = booking.Id,
                          FlightCode = flight.FlightCode,
                          FlightDate = Convert.ToDateTime(booking.FlightDate).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
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
                          Avatar = StringInfo.GetNextTextElement(booking.FirstName!, 0).ToUpper() + "" + StringInfo.GetNextTextElement(booking.LastName!, 0).ToUpper(),
                          AvatarColor = booking.AvatarColor
                      }).ToListAsync();
    }
}

