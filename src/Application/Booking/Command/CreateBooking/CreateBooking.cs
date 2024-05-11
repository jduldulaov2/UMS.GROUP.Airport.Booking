
using UMS.GROUP.Airport.Booking.Application.Booking.Command.CreateBooking;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateBookingCommand : IRequest<Result<CreateBookingCommandDto>>
{
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

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Result<CreateBookingCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateBookingCommandDto>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        string[] AvatarColor = { "#E93B8B", "#AF77E3", "#5985DE", "#7ED37B", "#2ED6EE", "#3F8FAB", "#E93B8B", "#AF77E3", "#5985DE", "#7ED37B", "#2ED6EE", "#3F8FAB", "#E93B8B", "#AF77E3", "#5985DE", "#7ED37B", "#2ED6EE", "#3F8FAB", "#E93B8B", "#AF77E3", "#5985DE", "#7ED37B", "#2ED6EE", "#3F8FAB", "#E93B8B", "#AF77E3", "#5985DE", "#7ED37B", "#2ED6EE", "#3F8FAB", "#E93B8B", "#AF77E3", "#5985DE", "#7ED37B", "#2ED6EE", "#3F8FAB" };

        var entity = new PassengerBooking();

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

        entity.AvatarColor = AvatarColor[new Random().Next(0, AvatarColor.Length)];

        _context.PassengerBooking.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Data = new CreateBookingCommandDto
            {
                Id = entity.UniqueId,
                CreatedDate = DateTime.Now,
            },
            Message = "success",
            ResultType = ResultType.Success,
        };
    }
}
