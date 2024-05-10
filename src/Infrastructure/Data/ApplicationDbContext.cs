﻿using System.Reflection;
using UMS.GROUP.Airport.Booking.Domain.Entities;
using UMS.GROUP.Airport.Booking.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<SystemEnvironment> SystemEnvironment => Set<SystemEnvironment>();
    public DbSet<Airport> Airport => Set<Airport>();

    public DbSet<Country> Country => Set<Country>();

    public DbSet<Plane> Plane => Set<Plane>();

    public DbSet<Flight> Flight => Set<Flight>();

    IQueryable<IdentityUser> IApplicationDbContext.Users => this.Users;
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}