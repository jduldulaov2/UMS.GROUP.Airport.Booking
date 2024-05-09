namespace UMS.GROUP.Airport.Booking.Application.Common.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base() { }

    public ForbiddenAccessException(string message) : base(message) { }
}
