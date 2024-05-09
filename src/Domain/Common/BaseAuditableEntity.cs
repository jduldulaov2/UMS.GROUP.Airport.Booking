using System.ComponentModel.DataAnnotations;

namespace UMS.GROUP.Airport.Booking.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public bool? IsActive { get; set; }

    public DateTimeOffset Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    [Timestamp]
    public byte[]? RowVersion { get; set; }


}
