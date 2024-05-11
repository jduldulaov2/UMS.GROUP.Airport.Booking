using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAllAirport;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAirportByName;

public record GetAirportByNameQuery : IRequest<List<GetAirportByNameQueryDto>>
{
    public string? AirportName { get; set; }
}

public class GetAirportByNameQueryHandler : IRequestHandler<GetAirportByNameQuery, List<GetAirportByNameQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetAirportByNameQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAirportByNameQueryDto>> Handle(GetAirportByNameQuery request, CancellationToken cancellationToken)
    {
        return await (from airport in _context.Airport
                      join country in _context.Country on airport.CountryId equals country.Id
                      where EF.Functions.Like(airport.AirportName, "%"+ request.AirportName + "%")
                      select new GetAirportByNameQueryDto
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
