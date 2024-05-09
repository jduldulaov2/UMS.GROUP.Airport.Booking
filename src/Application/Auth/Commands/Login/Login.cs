using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Application.Auth.Commands.Login;
public record LoginCommand : IRequest<Result<LoginDto>>
{
    public string? UserName { get; init; }
    public string? Password { get; init; }
    public bool IsPersistent { get; init; }
    public bool LockOutOnFailure { get; init; }

}

public class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginDto>>
{
    private readonly IIdentityService _identityService;

    public LoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<LoginDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.LoginAsync(request.UserName, request.Password, request.IsPersistent, request.LockOutOnFailure);
    }
}
