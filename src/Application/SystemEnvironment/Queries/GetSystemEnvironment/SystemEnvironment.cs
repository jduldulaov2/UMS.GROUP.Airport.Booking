using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMS.GROUP.Airport.Booking.Application.Auth.Commands.Login;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

namespace UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Queries.GetSystemEnvironment;

public record SystemEnvironmentQuery : IRequest<Result<SystemEnvironmentQueryDto>>
{

}

public class GetSystemEnvironmentHandler : IRequestHandler<SystemEnvironmentQuery, Result<SystemEnvironmentQueryDto>>
{
    private readonly IApplicationDbContext _context;

    public GetSystemEnvironmentHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<SystemEnvironmentQueryDto>> Handle(SystemEnvironmentQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.SystemEnvironment.Take(1).OrderByDescending(x => x.Id).ToListAsync();

        return new()
        {
            Data = new SystemEnvironmentQueryDto
            {
                Id = result.First().Id,
                UniqueId = result.First().UniqueId,
                SystemName = result.First().SystemName,
                EmailServer = result.First().EmailServer,
                EmailAddress = result.First().EmailAddress,
                EmailPassword = result.First().EmailPassword,
                SMTPPort = result.First().SMTPPort,
                IsSSL = result.First().IsSSL,
                UserRegistrationHTMLTemplate = result.First().UserRegistrationHTMLTemplate,
                UserRegistrationHTMLSubject = result.First().UserRegistrationHTMLSubject
            },
            Message = "success",
            ResultType = ResultType.Success,
        };
    }
}
