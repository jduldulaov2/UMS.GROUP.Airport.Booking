using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetAllPlanes;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Planes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllPlanes, "GetAllPlanes");
    }


    public async Task<List<GetAllPlanesQueryDto>> GetAllPlanes(ISender sender, [AsParameters] GetAllPlanesQuery query)
    {
        return await sender.Send(query);
    }

}
