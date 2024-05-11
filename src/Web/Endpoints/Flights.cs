﻿using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetAllFlight;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightById;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightByName;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Flights : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllFlights, "GetAllFlights")
            .MapGet(GetFlightById, "GetFlightById")
            .MapGet(GetFlightByName, "GetFlightByName")
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

    public async Task<List<GetFlightNameQueryDto>> GetFlightByName(ISender sender, [AsParameters] GetFlightByNameQuery query)
    {
        return await sender.Send(query);
    }

}