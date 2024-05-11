using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetAllPlanes;
using UMS.GROUP.Airport.Booking.Domain.Entities;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneByName;

public record GetPlaneByNameQuery : IRequest<List<GetPlaneByNameQueryDto>>
{
    public string? AirlineName { get; set; }
}

public class GetAllPlanesQueryHandler : IRequestHandler<GetPlaneByNameQuery, List<GetPlaneByNameQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAllPlanesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetPlaneByNameQueryDto>> Handle(GetPlaneByNameQuery request, CancellationToken cancellationToken)
    {
        return await (from plane in _context.Plane
                      where EF.Functions.Like(plane.AirlineName, "%" + request.AirlineName + "%")
                      select new GetPlaneByNameQueryDto
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
