using UMS.GROUP.Airport.Booking.Application.Common.Interfaces;
using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.CreateSystemEnvironment;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record CreateSystemEnvironmentCommand : IRequest<Result<SystemEnvironmentDto>>
{
    public string? SystemName { get; init; }

    public string? EmailServer { get; init; }

    public string? EmailAddress { get; init; }

    public string? EmailPassword { get; init; }

    public string? SMTPPort { get; init; }

    public bool? IsSSL { get; init; }

    public string? UserRegistrationHTMLTemplate { get; init; }

    public string? UserRegistrationHTMLSubject { get; init; }
}

public class CreateSystemEnvironmentCommandHandler : IRequestHandler<CreateSystemEnvironmentCommand, Result<SystemEnvironmentDto>>
{
    private readonly IApplicationDbContext _context;

    public CreateSystemEnvironmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<SystemEnvironmentDto>> Handle(CreateSystemEnvironmentCommand request, CancellationToken cancellationToken)
    {
        var entity = new SystemEnvironment();

        entity.SystemName = request.SystemName;

        entity.EmailServer = request.EmailServer;

        entity.EmailAddress = request.EmailAddress;

        entity.EmailPassword = request.EmailPassword;

        entity.SMTPPort = request.SMTPPort;

        entity.IsSSL = request.IsSSL;

        entity.UserRegistrationHTMLTemplate = request.UserRegistrationHTMLTemplate;

        entity.UserRegistrationHTMLSubject = request.UserRegistrationHTMLSubject;

        _context.SystemEnvironment.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return new()
        {
            Data = new SystemEnvironmentDto
            {
                Id = entity.UniqueId,
                CreatedDate = DateTime.Now,
            },
            Message = "success",
            ResultType = ResultType.Success,
        };
    }
}

