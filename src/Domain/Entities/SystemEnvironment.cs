using System.ComponentModel.DataAnnotations.Schema;

namespace UMS.GROUP.Airport.Booking.Domain.Entities;
public class SystemEnvironment : BaseAuditableEntity
{
    public string? SystemName { get; set; }

    public string? EmailServer { get; set; }

    public string? EmailAddress { get; set; }

    public string? EmailPassword { get; set; }

    public string? SMTPPort { get; set; }

    public bool? IsSSL { get; set; }

    [Column(TypeName = "text")]
    public string? UserRegistrationHTMLTemplate { get; set; }

    public string? UserRegistrationHTMLSubject { get; set; }
}
