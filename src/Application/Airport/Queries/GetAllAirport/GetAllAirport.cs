using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetAllBooking;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAllAirport;

public record GetAllAirportQuery : IRequest<List<GetAllAirportQueryDto>>
{

}

public class GetMediaDetailQueryHandler : IRequestHandler<GetAllAirportQuery, List<GetAllAirportQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllAirportQueryDto>> Handle(GetAllAirportQuery request, CancellationToken cancellationToken)
    {
        return await (from airport in _context.Airport
                      join country in _context.Country on airport.CountryId equals country.Id
                      select new GetAllAirportQueryDto
                      {
                          Id = airport.Id,
                          AirportName = airport.AirportName,
                          CountryName = country.CountryName,
                          City = airport.City,
                          Street = airport.Street,
                          Province = airport.Province,
                          Region = airport.Region,  
                          CountryId = airport.CountryId,
                          UniqueId = airport.UniqueId,
                          ZipCode = airport.ZipCode,
                          IsActive = airport.IsActive == null ? true : airport.IsActive

                      }).ToListAsync();
    }
}

