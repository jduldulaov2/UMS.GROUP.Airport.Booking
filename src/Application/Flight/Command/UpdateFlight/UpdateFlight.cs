using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Flight.Command.UpdateFlight;

public record UpdateFlightCommand : IRequest<Result<UpdateFlightCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? FlightCode { get; init; }

    public int? AirportId { get; init; }

    public int? PlaneId { get; init; }

    public bool? IsActive {  get; init; }
}

public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand, Result<UpdateFlightCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateFlightCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateFlightCommandDto>> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
    {
        var record = _context.Flight.FirstOrDefault(item => item.FlightCode == request.FlightCode && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.Flight.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.FlightCode = request.FlightCode;

                entity.AirportId = request.AirportId;

                entity.PlaneId = request.PlaneId;

                entity.IsActive = request.IsActive;

                _context.Flight.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateFlightCommandDto
                    {
                        Id = entity.UniqueId,
                        UpdatedDate = DateTime.Now,
                    },
                    Message = "Updated successfully.",
                    ResultType = ResultType.Success,
                };
            }
        }
        else
        {
            return new()
            {
                Data = new UpdateFlightCommandDto
                {

                },
                Message = "Record '" + request.FlightCode + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateFlightCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
