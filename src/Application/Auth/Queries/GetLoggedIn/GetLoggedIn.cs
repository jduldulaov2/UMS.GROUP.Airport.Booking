using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;

namespace UMS.GROUP.Airport.Booking.Application.Auth.Queries.GetLoggedIn;

public record GetLoggedInQuery : IRequest<Result<GetLoggedInQueryDto>>
{

}

public class GetLoggedInQueryHandler : IRequestHandler<GetLoggedInQuery, Result<GetLoggedInQueryDto>>
{
    private readonly IIdentityService _identityService;

    public GetLoggedInQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<GetLoggedInQueryDto>> Handle(GetLoggedInQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetLoggedIn();
    }
}
