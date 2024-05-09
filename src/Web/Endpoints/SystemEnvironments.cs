using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.CreateSystemEnvironment;
using UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.UpdateSystemEnvironment;
using UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Queries.GetSystemEnvironment;
namespace UMS.GROUP.Airport.Booking.Web.Endpoints;
public class SystemEnvironments : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetSystemEnvironment)
            .MapPost(CreateSystemEnvironment)
            .MapPut(UpdateSystemEnvironment);
    }


    public Task<Result<SystemEnvironmentDto>> CreateSystemEnvironment(ISender sender, CreateSystemEnvironmentCommand command)
    {
        return sender.Send(command);
    }

    public async Task<Result<SystemEnvironmentQueryDto>> GetSystemEnvironment(ISender sender, [AsParameters] SystemEnvironmentQuery query)
    {
        return await sender.Send(query);
    }

    public Task<Result<UpdateSystemEnvironmentDto>> UpdateSystemEnvironment(ISender sender, UpdateSystemEnvironmentCommand command)
    {
        return sender.Send(command);
    }
}
