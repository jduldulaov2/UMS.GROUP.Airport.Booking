using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Country.Queries.GetAllCountry;

public record GetAllCountryQuery : IRequest<List<GetAllCountryQueryDto>>
{

}

public class GetMediaDetailQueryHandler : IRequestHandler<GetAllCountryQuery, List<GetAllCountryQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetMediaDetailQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllCountryQueryDto>> Handle(GetAllCountryQuery request, CancellationToken cancellationToken)
    {
        return await (from country in _context.Country
                      select new GetAllCountryQueryDto
                      {
                          Id = country.Id,
                          CountryCode = country.CountryCode,
                          CountryName = country.CountryName,
                          Description = country.Description,
                      }).ToListAsync();
    }
}
