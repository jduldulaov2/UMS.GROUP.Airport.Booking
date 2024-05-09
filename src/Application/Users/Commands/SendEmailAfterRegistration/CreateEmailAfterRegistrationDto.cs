using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.SendEmailAfterRegistration;
public class CreateEmailAfterRegistrationDto
{
    public DateTime? SentDate { get; set; }

    public string? FromMailServer { get; set; }
}
