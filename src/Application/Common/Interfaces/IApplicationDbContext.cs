using UMS.GROUP.Airport.Booking.Domain.Entities;
using Microsoft.AspNetCore.Identity;

public interface IApplicationDbContext
{
    IQueryable<IdentityUser> Users { get; }
    DbSet<SystemEnvironment> SystemEnvironment { get; }

    DbSet<Airport> Airport { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
