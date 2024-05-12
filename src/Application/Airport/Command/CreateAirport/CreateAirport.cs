using UMS.GROUP.Airport.Booking.Application.Airport.Command.CreateAirport;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateAirportCommand : IRequest<Result<CreateAirportCommandDto>>
{
    public string? AirportName { get; init; }

    public string? Street { get; init; }

    public string? City { get; init; }

    public string? Province { get; init; }

    public string? Region { get; init; }

    public string? ZipCode { get; init; }

    public int? CountryId { get; init; }

    public bool? IsActive { get; init; }
}

public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, Result<CreateAirportCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateAirportCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateAirportCommandDto>> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.Airport.Where(p => p.AirportName == request.AirportName).ToListAsync();

        if (record.Count == 0)
        {

            // Add new record

            var entity = new Airport();

            entity.AirportName = request.AirportName;

            entity.Street = request.Street;

            entity.City = request.City;

            entity.Province = request.Province;

            entity.Region = request.Region;

            entity.ZipCode = request.ZipCode;

            entity.CountryId = request.CountryId;

            entity.IsActive = request.IsActive;

            _context.Airport.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateAirportCommandDto
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
                Data = new CreateAirportCommandDto
                {

                },
                Message = "Record '" + request.AirportName + "' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}
