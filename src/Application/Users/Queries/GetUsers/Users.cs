using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace UMS.GROUP.Airport.Booking.Application.Users.Queries.GetUsers;
public record UsersQuery : IRequest<Result<UsersListDto>>
{
    public string? SearchValue { get; set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class UsersQueryHandler : IRequestHandler<UsersQuery, Result<UsersListDto>>
{
    private readonly IIdentityService _identityService;

    public UsersQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<UsersListDto>> Handle(UsersQuery request, CancellationToken cancellationToken)
    {
        return await this._identityService.AllUsersByName(request.SearchValue!);
    }
}
