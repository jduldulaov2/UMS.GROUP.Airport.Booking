namespace UMS.GROUP.Airport.Booking.Application.Common.Interfaces;

public interface IAuthService
{
    Task<bool> SignIn(string username, string password);
    Task SignOut();
}
