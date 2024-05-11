using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Plane.Command.CreateAirline;
using UMS.GROUP.Airport.Booking.Application.Plane.Command.UpdateAirline;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetAllPlanes;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneById;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneByName;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Planes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllPlanes, "GetAllPlanes")
            .MapGet(GetPlaneById, "GetPlaneById")
            .MapGet(GetPlaneByName, "GetPlaneByName")
            .MapPost(CreateAirline, "CreateAirline")
            .MapPut(UpdateAirline, "UpdateAirline")
            ;
    }


    public async Task<List<GetAllPlanesQueryDto>> GetAllPlanes(ISender sender, [AsParameters] GetAllPlanesQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetPlaneByIdQueryDto>> GetPlaneById(ISender sender, [AsParameters] GetPlaneByIdQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetPlaneByNameQueryDto>> GetPlaneByName(ISender sender, [AsParameters] GetPlaneByNameQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateAirlineCommandDto>> CreateAirline(ISender sender, CreateAirlineCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateAirlineCommandDto>> UpdateAirline(ISender sender, UpdateAirlineCommand command)
    {
        return sender.Send(command);
    }

}
