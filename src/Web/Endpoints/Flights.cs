using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetAllFlight;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightById;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Flights : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllFlights, "GetAllFlights")
            .MapGet(GetFlightById, "GetFlightById")
            ;
    }


    public async Task<List<GetAllFlightQueryDto>> GetAllFlights(ISender sender, [AsParameters] GetAllFlightQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetFlightByIdQueryDto>> GetFlightById(ISender sender, [AsParameters] GetFlightByIdQuery query)
    {
        return await sender.Send(query);
    }

}
