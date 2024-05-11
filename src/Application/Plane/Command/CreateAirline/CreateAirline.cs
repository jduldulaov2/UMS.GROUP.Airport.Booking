using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Plane.Command.CreateAirline;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateAirlineCommand : IRequest<Result<CreateAirlineCommandDto>>
{
    public string? AirlineName { get; init; }

    public string? Code { get; init; }

    public string? Model { get; init; }
}

public class CreateAirlineCommandHandler : IRequestHandler<CreateAirlineCommand, Result<CreateAirlineCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateAirlineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<CreateAirlineCommandDto>> Handle(CreateAirlineCommand request, CancellationToken cancellationToken)
    {
        var record = await _context.Plane.Where(p => p.AirlineName == request.AirlineName).ToListAsync();

        if (record.Count == 0) {

            // Add new record

            var entity = new Plane();

            entity.AirlineName = request.AirlineName;

            entity.Code = request.Code;

            entity.Model = request.Model;

            _context.Plane.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new CreateAirlineCommandDto
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
                Data = new CreateAirlineCommandDto
                {
                    
                },
                Message = "Record '"+request.AirlineName+"' already exist",
                ResultType = ResultType.Error,
            };
        }
    }
}
