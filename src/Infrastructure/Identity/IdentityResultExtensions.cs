using UMS.GROUP.Airport.Booking.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace UMS.GROUP.Airport.Booking.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result)
    {
        return result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
    }
}
