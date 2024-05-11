
using UMS.GROUP.Airport.Booking.Application.Airport.Command.CreateAirport;
using UMS.GROUP.Airport.Booking.Application.Airport.Command.UpdateAirport;
using UMS.GROUP.Airport.Booking.Application.Booking.Command.CreateBooking;
using UMS.GROUP.Airport.Booking.Application.Booking.Command.UpdateBooking;
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetAllBooking;
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingById;
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingByName;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Bookings : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllBookings, "GetAllBookings")
            .MapGet(GetBookingById, "GetBookingById")
            .MapGet(GetBookingByName, "GetBookingByName")
            .MapPost(CreateBooking, "CreateBooking")
            .MapPut(UpdateBooking, "UpdateBooking")
            ;
    }


    public async Task<List<GetAllBookingQueryDto>> GetAllBookings(ISender sender, [AsParameters] GetAllBookingQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetBookingByIdQueryDto>> GetBookingById(ISender sender, [AsParameters] GetBookingByIdQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetBookingByNameQueryDto>> GetBookingByName(ISender sender, [AsParameters] GetBookingByNameQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateBookingCommandDto>> CreateBooking(ISender sender, CreateBookingCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateBookingCommandDto>> UpdateBooking(ISender sender, UpdateBookingCommand command)
    {
        return sender.Send(command);
    }

}
