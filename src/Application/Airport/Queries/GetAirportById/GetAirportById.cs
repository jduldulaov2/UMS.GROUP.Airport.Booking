using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Queries.GetSystemEnvironment;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAirportById;

public record GetAirportByIdQuery : IRequest<Result<GetAirportByIdQueryDto>>
{
    public int? AirportId { get; set; }
}

public class GetAirportByIdQueryHandler : IRequestHandler<GetAirportByIdQuery, Result<GetAirportByIdQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAirportByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<GetAirportByIdQueryDto>> Handle(GetAirportByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Airport.SingleOrDefaultAsync(i => i.Id == request.AirportId);

        if (result != null)
        {
            return new()
            {
                Data = new GetAirportByIdQueryDto
                {
                    Id = result.Id,
                    AirportName = result.AirportName,
                    CountryId = result.CountryId,
                    Street = result.Street,
                    City = result.City,
                    Province = result.Province,
                    Region = result.Region,
                    ZipCode = result.ZipCode,
                    UniqueId = result.UniqueId
                },
                Message = "success",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new GetAirportByIdQueryDto
            {

            },
            Message = "failed - no record found",
            ResultType = ResultType.Error,
        };

    }
}
