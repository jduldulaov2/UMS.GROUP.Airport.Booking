﻿
using UMS.GROUP.Airport.Booking.Application.Airport.Queries.GelAllAirportByCountry;
using UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAirportById;
using UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAirportByName;
using UMS.GROUP.Airport.Booking.Application.Airport.Queries.GetAllAirport;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Airport : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllAirportByCountry, "GetAllAirportByCountry")
            .MapGet(GetAirportById, "GetAirportById")
            .MapGet(GetAllAirport, "GetAllAirport")
            .MapGet(GetAirportByName, "GetAirportByName")
            ;
    }


    public async Task<List<GetAllAirportByCountryQueryDto>> GetAllAirportByCountry(ISender sender, [AsParameters] GelAllAirportByCountryQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetAirportByIdQueryDto>> GetAirportById(ISender sender, [AsParameters] GetAirportByIdQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetAllAirportQueryDto>> GetAllAirport(ISender sender, [AsParameters] GetAllAirportQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetAirportByNameQueryDto>> GetAirportByName(ISender sender, [AsParameters] GetAirportByNameQuery query)
    {
        return await sender.Send(query);
    }

}