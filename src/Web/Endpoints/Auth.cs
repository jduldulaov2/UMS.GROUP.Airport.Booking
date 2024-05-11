using UMS.GROUP.Airport.Booking.Application.Auth.Commands.Login;
using UMS.GROUP.Airport.Booking.Application.Auth.Commands.Logout;
using UMS.GROUP.Airport.Booking.Application.Auth.Queries.GetLoggedIn;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Auth : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(Login, "Login")
            .MapGet(LogOut, "LogOut")
            .MapGet(GeLoggedIn, "GeLoggedIn")
            ;
    }

    public async Task<Result<LoginDto>> Login(ISender sender, [AsParameters] LoginCommand query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<LogoutDto>> LogOut(ISender sender, [AsParameters] LogoutCommand query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<GetLoggedInQueryDto>> GeLoggedIn(ISender sender, [AsParameters] GetLoggedInQuery query)
    {
        return await sender.Send(query);
    }

}
