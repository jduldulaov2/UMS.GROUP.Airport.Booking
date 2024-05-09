using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
public interface IJsonService
{
    string ConvertToJson(object datatoconvert);

    Task<string> ConvertToJsonAsync(object datatoconvert);
}
