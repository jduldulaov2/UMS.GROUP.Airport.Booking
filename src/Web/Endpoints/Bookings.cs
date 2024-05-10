
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetAllBooking;
using UMS.GROUP.Airport.Booking.Application.Booking.Queries.GetBookingById;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Bookings : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetAllBookings, "GetAllBookings")
            .MapGet(GetBookingById, "GetBookingById")
            ;
    }


    public async Task<List<GetAllBookingQueryDto>> GetAllBookings(ISender sender, [AsParameters] GetAllBookingQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<GetBookingByIdQueryDto>> GetBookingById(ISender sender, [AsParameters] GetBookingByIdQuery query)
    {
        return await sender.Send(query);
    }

}
