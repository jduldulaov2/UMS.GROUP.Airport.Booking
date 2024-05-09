using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;

namespace UMS.GROUP.Airport.Booking.Infrastructure.Helpers;
public class EmailService : IEmailService
{
    public async Task<bool> SendEmail(string emailServer, string emailFrom, string emailPassword, string emailTo, string emailSubject, string emailBody, bool isBodyHtml, int port, bool isSSL)
    {
        var email = new MailMessage();

        bool isSSLEnabled = isSSL;

        //Set the sender
        email.From = new MailAddress(emailFrom);

        //Set the subject
        email.Subject = emailSubject;

        //Set the recepient of the email (newly added user)
        email.To.Add(new MailAddress(emailTo));

        //Set the email body with values
        email.Body = emailBody;

        //Set if body HTML
        email.IsBodyHtml = isBodyHtml;

        //Finalize the email settings
        using var smtpClient = new SmtpClient
        {
            // Set the host example smtp.gmail.com
            Host = emailServer,

            //Set the port exmaple 587
            Port = port,

            //Set the SMTP Account
            Credentials = new NetworkCredential(emailFrom, emailPassword),

            //Set the SSL
            EnableSsl = isSSLEnabled
        };

        //Send the email to receiver
        await smtpClient.SendMailAsync(email);

        return true;
    }
}
