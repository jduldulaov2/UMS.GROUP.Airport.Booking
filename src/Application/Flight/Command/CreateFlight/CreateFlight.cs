using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Flight.Command.CreateFlight;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateFlightCommand : IRequest<Result<CreateFlightCommandDto>>
{
    public string? FlightCode { get; init; }

    public int? AirportId { get; init; }

    public int? PlaneId { get; init; }
}

public class CreateFlightCommandCommandHandler : IRequestHandler<CreateFlightCommand, Result<CreateFlightCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateFlightCommandCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateFlightCommandDto>> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.Flight.Where(p => p.FlightCode == request.FlightCode).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new Flight();

            entity.FlightCode = request.FlightCode;

            entity.AirportId = request.AirportId;

            entity.PlaneId = request.PlaneId;

            _context.Flight.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateFlightCommandDto
                {
                    Id = entity.UniqueId,
                    CreatedDate = DateTime.Now,
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }
        else
        {
            return new()
            {
                Data = new CreateFlightCommandDto
                {

                },
                Message = "Record '" + request.FlightCode + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}
