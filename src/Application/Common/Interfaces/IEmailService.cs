namespace UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
public interface IEmailService
{
    Task<bool> SendEmail(string emailServer, string emailFrom, string emailPassword, string emailTo, string emailSubject, string emailBody, bool isBodyHtml, int port, bool isSSL);
}
