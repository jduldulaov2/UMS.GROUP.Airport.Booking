using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Airport.Queries.GelAllAirportByCountry;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetAllPlanes;

public record GetAllPlanesQuery : IRequest<List<GetAllPlanesQueryDto>>
{

}

public class GetAllPlanesQueryHandler : IRequestHandler<GetAllPlanesQuery, List<GetAllPlanesQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllPlanesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllPlanesQueryDto>> Handle(GetAllPlanesQuery request, CancellationToken cancellationToken)
    {
        return await (from plane in _context.Plane
                      select new GetAllPlanesQueryDto
                      {
                          Id = plane.Id,
                          AirlineName = plane.AirlineName,
                          Code = plane.Code,
                          Model = plane.Model,
                          UniqueId = plane.UniqueId,
                          IsActive = plane.IsActive == null ? true : plane.IsActive
                      }).ToListAsync();
    }
}
