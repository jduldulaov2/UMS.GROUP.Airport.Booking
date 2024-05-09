using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Users.Commands.CreateUser;
using UMS.GROUP.Airport.Booking.Application.Users.Commands.UpdatePassword;
using UMS.GROUP.Airport.Booking.Application.Users.Commands.UpdateUser;
using UMS.GROUP.Airport.Booking.Application.Users.Queries.GeneratePassword;
using UMS.GROUP.Airport.Booking.Application.Users.Queries.GetUserByID;
using UMS.GROUP.Airport.Booking.Application.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;

namespace UMS.GROUP.Airport.Booking.Web.Endpoints;

public class Users: EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(AllUsersByName, "AllUsersByName")
            .MapGet(GetUserByID, "GetUserByID")
            .MapPost(CreateIdentityUser, "CreateUser")
            .MapPut(UpdateIdentityUser, "UpdateUser")
            .MapPut(UpdatePassword, "UpdatePassword")
            .MapGet(GetPassword, "GenerateRandomPassword")
            ;
    }

    public async Task<Result<UserByIDDto>> GetUserByID(ISender sender, [AsParameters] GetUserByIDQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<Result<UsersListDto>> AllUsersByName(ISender sender, [AsParameters] UsersQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<CreateUserDto>> CreateIdentityUser(ISender sender, CreateUserCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdateUserDto>> UpdateIdentityUser(ISender sender, UpdateUserCommand command)
    {
        return sender.Send(command);
    }

    public Task<Result<UpdatePasswordDto>> UpdatePassword(ISender sender, UpdatePasswordCommand command)
    {
        return sender.Send(command);
    }

    public async Task<Result<GeneratePasswordDto>> GetPassword(ISender sender, [AsParameters] GeneratePasswordQuery query)
    {
        return await sender.Send(query);
    }

}
