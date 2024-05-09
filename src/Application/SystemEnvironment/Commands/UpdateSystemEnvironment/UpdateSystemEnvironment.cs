using UMS.GROUP.Airport.Booking.Application.Common.Models;
using UMS.GROUP.Airport.Booking.Application.Common.Models.Enums;
using UMS.GROUP.Airport.Booking.Application.SystemEnvironment.Commands.UpdateSystemEnvironment;
using UMS.GROUP.Airport.Booking.Domain.Entities;

public record UpdateSystemEnvironmentCommand : IRequest<Result<UpdateSystemEnvironmentDto>>
{
    public int Id { get; init; }
    public string? SystemName { get; init; }

    public string? EmailServer { get; init; }

    public string? EmailAddress { get; init; }

    public string? EmailPassword { get; init; }

    public string? SMTPPort { get; init; }

    public bool? IsSSL { get; init; }

    public string? UserRegistrationHTMLTemplate { get; init; }

    public string? UserRegistrationHTMLSubject { get; init; }
}

public class UpdateSystemEnvironmentCommandHandler : IRequestHandler<UpdateSystemEnvironmentCommand, Result<UpdateSystemEnvironmentDto>>
{
    private readonly IApplicationDbContext _context;

    public UpdateSystemEnvironmentCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Result<UpdateSystemEnvironmentDto>> Handle(UpdateSystemEnvironmentCommand request, CancellationToken cancellationToken)
    {
        var entity = _context.SystemEnvironment.FirstOrDefault(item => item.Id == request.Id);

        if (entity != null)
        {
            entity.SystemName = request.SystemName;

            entity.EmailServer = request.EmailServer;

            entity.EmailAddress = request.EmailAddress;

            entity.EmailPassword = request.EmailPassword;

            entity.SMTPPort = request.SMTPPort;

            entity.IsSSL = request.IsSSL;

            entity.UserRegistrationHTMLTemplate = request.UserRegistrationHTMLTemplate;

            entity.UserRegistrationHTMLSubject = request.UserRegistrationHTMLSubject;

            _context.SystemEnvironment.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return new()
            {
                Data = new UpdateSystemEnvironmentDto
                {
                    Id = entity.UniqueId,
                    UpdatedDate = DateTime.Now,
                },
                Message = "updated successfully",
                ResultType = ResultType.Success,
            };
        }

        return new()
        {
            Data = new UpdateSystemEnvironmentDto
            {
                
            },
            Message = "update failed",
            ResultType = ResultType.Error,
        };

    }
}

