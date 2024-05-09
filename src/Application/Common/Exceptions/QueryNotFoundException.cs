namespace UMS.GROUP.Airport.Booking.Application.Common.Exceptions;

public class QueryNotFoundException : Exception
{
    public QueryNotFoundException()
    {
    }

    public QueryNotFoundException(string message) : base(message)
    {
    }

    public QueryNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}
