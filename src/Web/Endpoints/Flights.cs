using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Flight.Command.CreateFlight;
using UMS.GROUP.Airport.Booking.Application.Flight.Command.UpdateFlight;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetAllFlight;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightById;
using UMS.GROUP.Airport.Booking.Application.Flight.Queries.GetFlightByName;
using UMS.GROUP.Airport.Booking.Application.Plane.Command.UpdateAirline;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Flights : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllFlights, "GetAllFlights")
            .MapGet(GetFlightById, "GetFlightById")
            .MapGet(GetFlightByName, "GetFlightByName")
            .MapPost(CreateFlight, "CreateFlight")
            .MapPut(UpdateFlight, "UpdateFlight")
            ;
    }


    public async Task<List<GetAllFlightQueryDto>> GetAllFlights(ISender sender, [AsParameters] GetAllFlightQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetFlightByIdQueryDto>> GetFlightById(ISender sender, [AsParameters] GetFlightByIdQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetFlightNameQueryDto>> GetFlightByName(ISender sender, [AsParameters] GetFlightByNameQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateFlightCommandDto>> CreateFlight(ISender sender, CreateFlightCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateFlightCommandDto>> UpdateFlight(ISender sender, UpdateFlightCommand command)
    {
        return sender.Send(command);
    }

}
