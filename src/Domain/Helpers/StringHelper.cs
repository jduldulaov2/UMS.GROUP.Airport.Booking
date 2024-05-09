using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Domain.Helpers;
public static class StringHelper
{
    public static string ResolveNull(this string? val)
    {
        return val is null ? "" : val.ToString();

    }
}
