using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.UpdatePassword;

public record UpdatePasswordCommand : IRequest<Result<UpdatePasswordDto>>
{
    public string? UserName { get; init; }

    public string? OldPassword { get; init; }

    public string? NewPassword { get; init; }

}

public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, Result<UpdatePasswordDto>>
{
    private readonly IIdentityService _identityService;
    public UpdatePasswordCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<UpdatePasswordDto>> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.UpdateIdentityUserPasswordAsync(request.UserName, request.OldPassword, request.NewPassword);
    }
}
