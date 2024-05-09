using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Auth.Commands.Logout;
public class LogoutDto
{
    public string? UserId { get; set; }
    public DateTime? Time { get; set; }
}
