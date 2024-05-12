
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.Plane.Command.UpdateAirline;

public record UpdateAirlineCommand : IRequest<Result<UpdateAirlineCommandDto>>
{
    public string? UniqueId { get; init; }

    public string? AirlineName { get; init; }

    public string? Code { get; init; }

    public string? Model { get; init; }

    public bool? IsActive { get; init; }
}

public class UpdateAirlineCommandHandler : IRequestHandler<UpdateAirlineCommand, Result<UpdateAirlineCommandDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateAirlineCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateAirlineCommandDto>> Handle(UpdateAirlineCommand request, CancellationToken cancellationToken)
    {
        var record = _context.Plane.FirstOrDefault(item => item.AirlineName == request.AirlineName && item.UniqueId != request.UniqueId);

        if (record == null)
        {
            var entity = _context.Plane.FirstOrDefault(item => item.UniqueId == request.UniqueId);

            if (entity != null)
            {
                entity.AirlineName = request.AirlineName;

                entity.Code = request.Code;

                entity.Model = request.Model;

                entity.IsActive = request.IsActive;

                _context.Plane.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return new()
                {
                    Data = new UpdateAirlineCommandDto
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
                Data = new UpdateAirlineCommandDto
                {

                },
                Message = "Record '" + request.AirlineName + "' already exist.",
                ResultType = ResultType.Error,
            };
        }

        return new()
        {
            Data = new UpdateAirlineCommandDto
            {

            },
            Message = "No record found.",
            ResultType = ResultType.Error,
        };

    }
}
