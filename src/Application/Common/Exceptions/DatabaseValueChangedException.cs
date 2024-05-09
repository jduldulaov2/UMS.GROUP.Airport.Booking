namespace UMS.GROUP.Airport.Booking.Application.Common.Exceptions;

public class DatabaseValueChangedException : Exception
{
    public DatabaseValueChangedException()
    {
    }

    public DatabaseValueChangedException(string message) : base(message)
    {
    }

    public DatabaseValueChangedException(string message, Exception inner) : base(message, inner)
    {
    }
}
