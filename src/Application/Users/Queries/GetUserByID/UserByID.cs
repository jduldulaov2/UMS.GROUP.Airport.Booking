using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Domain.Constants;


namespace UMS.GROUP.Airport.Booking.Application.Users.Queries.GetUserByID;
public record GetUserByIDQuery : IRequest<Result<UserByIDDto>>
{
    public string? Id { get; init; }
}

public class GetUserByIDHandler : IRequestHandler<GetUserByIDQuery, Result<UserByIDDto>>
{
    private readonly IIdentityService _identityService;

    public GetUserByIDHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<UserByIDDto>> Handle(GetUserByIDQuery request, CancellationToken cancellationToken)
    {
        return await this._identityService.GetUserById(request.Id!);
    }
}
