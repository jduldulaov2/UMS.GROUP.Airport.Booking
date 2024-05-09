using System.Text.Json;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

namespace UMS.GROUP.Airport.Booking.Application.Common.Models;

public class ErrorResult
{
    public ErrorResult() => ResultType = ResultType.Error;

    public ResultType ResultType { get; set; }
    public string Message { get; set; } = null!;

    public override string ToString() => JsonSerializer.Serialize(this, DefaultSerializerOptions());

    private static JsonSerializerOptions DefaultSerializerOptions() => new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
}
