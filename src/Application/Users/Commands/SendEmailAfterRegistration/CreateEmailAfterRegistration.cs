using System.Net.Mail;
using System.Net;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;

namespace UMS.GROUP.Airport.Booking.Application.Users.Commands.SendEmailAfterRegistration;

public record CreateEmailAfterRegistrationCommand : IRequest<Result<CreateEmailAfterRegistrationDto>>
{
    public string? EmailAddress { get; init; }

    public string? FullName { get; init; }

    public string? UserName { get; init; }

    public string? Password { get; init; }
}

public class CreateEmailAfterRegistrationnCommandHandler : IRequestHandler<CreateEmailAfterRegistrationCommand, Result<CreateEmailAfterRegistrationDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IEmailService _emailService;
    public CreateEmailAfterRegistrationnCommandHandler(IApplicationDbContext context, IEmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task<Result<CreateEmailAfterRegistrationDto>> Handle(CreateEmailAfterRegistrationCommand request, CancellationToken cancellationToken)
    {
        // Get theh email template from table UMS.GROUP.Airport.Booking.SystemEnvironment
        var emailParams = await _context.SystemEnvironment.Take(1).OrderByDescending(x => x.Id).ToListAsync();

        // Set the SSL validity
        bool isSSL = emailParams.First().IsSSL ?? false;

        var sendEmailToNewlyAddedUser = await _emailService
            .SendEmail(
                emailParams.First().EmailServer!,
                //Set the sender
                emailParams.First().EmailAddress!,
                //Set the SMTP Account password
                emailParams.First().EmailPassword!,
                //Set the recepient of the email (newly added user)
                request.EmailAddress!,
                //Set the subject
                emailParams.First().UserRegistrationHTMLSubject!,
                //Set the subject
                emailParams.First().UserRegistrationHTMLTemplate!
                    .Replace("{name}", request.FullName)
                    .Replace("{username}", request.UserName)
                    .Replace("{password}", request.Password),
                //Set if body HTML - default to true
                true,
                //Set the port exmaple 587
                int.Parse(emailParams.First().SMTPPort!),
                //Set the SSL
                isSSL);

        if (sendEmailToNewlyAddedUser)
        {
            return new()
            {
                Data = new CreateEmailAfterRegistrationDto
                {
                    SentDate = DateTime.Now,
                    FromMailServer = emailParams.First().EmailServer!
                },
                Message = "sent email successfully",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new CreateEmailAfterRegistrationDto
            {
                SentDate = DateTime.Now,
                FromMailServer = emailParams.First().EmailServer!
            },
            Message = "sent email unsuccessful",
            ResultType = ResultType.Error,
        };

    }
}
