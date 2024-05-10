using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Country.Queries.GetAllCountry;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Country : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCountry);
    }


    public async Task<List<GetAllCountryQueryDto>> GetCountry(ISender sender, [AsParameters] GetAllCountryQuery query)
    {
        return await sender.Send(query);
    }

}
