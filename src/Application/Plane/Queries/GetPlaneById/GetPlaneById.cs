using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneById;
public record GetPlaneByIdQuery : IRequest<Result<GetPlaneByIdQueryDto>>
{
    public string? UniqueId { get; set; }
}

public class GetPlaneByIdQueryHandler : IRequestHandler<GetPlaneByIdQuery, Result<GetPlaneByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetPlaneByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetPlaneByIdQueryDto>> Handle(GetPlaneByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Plane.SingleOrDefaultAsync(i => i.UniqueId == request.UniqueId);

        if (result != null)
        {
            return new()
            {
                Data = new GetPlaneByIdQueryDto
                {
                    Id = result.Id,
                    AirlineName = result.AirlineName,
                    Code = result.Code,
                    Model = result.Model,
                    UniqueId = result.UniqueId,
                    IsActive = result.IsActive == null ? true : result.IsActive
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetPlaneByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
