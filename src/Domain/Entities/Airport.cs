namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class Airport : BaseAuditableEntity
{
    public string? AirportName { get; set; }

    public int? CountryId { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Region { get; set; }

    public string? ZipCode { get; set; }
}
