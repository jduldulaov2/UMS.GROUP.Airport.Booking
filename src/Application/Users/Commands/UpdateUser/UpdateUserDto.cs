using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.UpdateUser;
public class UpdateUserDto
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? EmailAddress { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? Province { get; set; }

    public string? Region { get; set; }

    public string? ZipCode { get; set; }

    public string? ContactNumber { get; set; }

}
