using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.CreateUser;
public record CreateUserCommand : IRequest<Result<CreateUserDto>>
{
    public string? UserName { get; init; }

    public string? Password { get; init; }

    public string? LastName { get; init; }

    public string? FirstName { get; init; }

    public string? MiddleName { get; init; }

    public string? EmailAddress { get; init; }

    public string? Street { get; init; }

    public string? City { get; init; }

    public string? Province { get; init; }

    public string? Region { get; init; }

    public string? ZipCode { get; init; }

    public string? ContactNumber { get; init; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<CreateUserDto>>
{
    private readonly IIdentityService _identityService;
    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<CreateUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
         return await _identityService.CreateIdentityUserAsync(
            request.UserName,request.Password,request.LastName,request.FirstName,request.MiddleName, 
            request.EmailAddress,request.Street,request.City,request.Province, request.Region, 
            request.ZipCode, request.ContactNumber);
    }
}
