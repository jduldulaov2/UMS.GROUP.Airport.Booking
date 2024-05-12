
using UMS.GROUP.Airport.Booking.Application.Airport.Command.UpdateAirport;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

public record UpdateAirportCommand : IRequest<Result<UpdateAirportCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? AirportName { get; init; }

    public string? Street { get; init; }

    public string? City { get; init; }

    public string? Province { get; init; }

    public string? Region { get; init; }

    public string? ZipCode { get; init; }

    public int? CountryId { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateAirportCommandHandler : IRequestHandler<UpdateAirportCommand, Result<UpdateAirportCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateAirportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateAirportCommandDto>> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
    {
        var record = _context.Airport.FirstOrDefault(item => item.AirportName == request.AirportName && item.UniqueId != request.UniqueId);
        
        if (record == null)
        {
            var entity = _context.Airport.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.AirportName = request.AirportName;

                entity.Street = request.Street;

                entity.City = request.City;

                entity.Province = request.Province;

                entity.Region = request.Region;

                entity.ZipCode = request.ZipCode;

                entity.CountryId = request.CountryId;

                entity.IsActive = request.IsActive;

                _context.Airport.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateAirportCommandDto
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
                Data = new UpdateAirportCommandDto
                {

                },
                Message = "Record '" + request.AirportName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateAirportCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
