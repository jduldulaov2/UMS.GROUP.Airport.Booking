using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightById;
using UMS.GROUP.Airport.Booking.Domain.Entities;

namespace UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingById;

public record GetBookingByIdQuery : IRequest<Result<GetBookingByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetMediaDetailQueryHandler : IRequestHandler<GetBookingByIdQuery, Result<GetBookingByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetBookingByIdQueryDto>> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.PassengerBooking.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetBookingByIdQueryDto
                {
                    Id = result.Id,
                    FlightId = result.FlightId,
                    FlightDate = Convert.ToDateTime(result.FlightDate).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    MiddleName = result.MiddleName,
                    Street = result.Street,
                    City = result.City,
                    ContactNumber = result.ContactNumber,
                    Region = result.Region,
                    Province = result.Province,
                    Destination = result.Destination,
                    Origin = result.Origin,
                    UniqueId = result.UniqueId,
                    ZipCode = result.ZipCode,
                    Avatar = StringInfo.GetNextTextElement(result.FirstName!, 0).ToUpper() + "" + StringInfo.GetNextTextElement(result.LastName!, 0).ToUpper(),
                    AvatarColor = result.AvatarColor
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetBookingByIdQueryDto
            {

            },
            Message = "Failed - no record found.",
            ResultType = ResultType.Error,
        };
    }
}
