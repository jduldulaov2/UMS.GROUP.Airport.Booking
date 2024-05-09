namespace UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
public interface IPassword
{
    Task<string> GeneratePasswordAsync(int lowercase, int uppercase, int numerics);
}
