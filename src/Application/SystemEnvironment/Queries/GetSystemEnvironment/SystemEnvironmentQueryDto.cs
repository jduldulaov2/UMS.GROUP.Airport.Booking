using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Queries.GetSystemEnvironment;
public class SystemEnvironmentQueryDto
{
    public int? Id { get; set; }

    public string? UniqueId { get; set; }

    public string? SystemName { get; set; }

    public string? EmailServer { get; set; }

    public string? EmailAddress { get; set; }

    public string? EmailPassword { get; set; }

    public string? SMTPPort { get; set; }

    public bool? IsSSL { get; set; }

    public string? UserRegistrationHTMLTemplate { get; set; }

    public string? UserRegistrationHTMLSubject { get; set; }
}
