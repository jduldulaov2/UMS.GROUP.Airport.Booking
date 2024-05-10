using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GelAllAirportByCountry;

public record GelAllAirportByCountryQuery : IRequest<List<GetAllAirportByCountryQueryDto>>
{
    public int? CountryId { get; set; }
}

public class GelAllAirportByCountryQueryHandler : IRequestHandler<GelAllAirportByCountryQuery, List<GetAllAirportByCountryQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GelAllAirportByCountryQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllAirportByCountryQueryDto>> Handle(GelAllAirportByCountryQuery request, CancellationToken cancellationToken)
    {
        return await (from airport in _context.Airport
                      where airport.CountryId == request.CountryId
                      select new GetAllAirportByCountryQueryDto
                      {
                          Id = airport.Id,
                          AirportName = airport.AirportName,
                          CountryId = airport.CountryId,
                          Street = airport.Street,
                          City = airport.City,
                          Province = airport.Province,
                          Region = airport.Region,
                          ZipCode = airport.ZipCode,
                          UniqueId = airport.UniqueId
                      }).ToListAsync();
    }
}
