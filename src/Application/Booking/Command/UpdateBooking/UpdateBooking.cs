using UMS.GROUP.Airport.Booking.Application.Booking.Command.UpdateBooking;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateBookingCommand : IRequest<Result<UpdateBookingCommandDto>>
{
    public string? UniqueId { get; init; }

    public int? FlightId { get; init; }

    public DateTime? FlightDate { get; init; }

    public string? Origin { get; init; }

    public string? Destination { get; init; }

    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    public string? MiddleName { get; init; }

    public string? Street { get; init; }

    public string? City { get; init; }

    public string? Province { get; init; }

    public string? Region { get; init; }

    public string? ZipCode { get; init; }

    public string? ContactNumber { get; init; }
}

public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand, Result<UpdateBookingCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateBookingCommandDto>> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.PassengerBooking.FirstOrDefault(item => item.UniqueId == request.UniqueId);

        if (entity != null)
        {
            entity.FlightId = request.FlightId;

            entity.FlightDate = request.FlightDate;

            entity.Origin = request.Origin;

            entity.Destination = request.Destination;

            entity.FirstName = request.FirstName;

            entity.LastName = request.LastName;

            entity.MiddleName = request.MiddleName;

            entity.Street = request.Street;

            entity.City = request.City;

            entity.Province = request.Province;

            entity.Region = request.Region;

            entity.ZipCode = request.ZipCode;

            entity.ContactNumber = request.ContactNumber;

            _context.PassengerBooking.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new UpdateBookingCommandDto
                {
                    Id = entity.UniqueId,
                    UpdatedDate = DateTime.Now,
                },
                Message = "Updated successfully.",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new UpdateBookingCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
