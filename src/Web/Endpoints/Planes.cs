﻿using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetAllPlanes;
using UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneById;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Planes : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllPlanes, "GetAllPlanes")
            .MapGet(GetPlaneById, "GetPlaneById")
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

}
