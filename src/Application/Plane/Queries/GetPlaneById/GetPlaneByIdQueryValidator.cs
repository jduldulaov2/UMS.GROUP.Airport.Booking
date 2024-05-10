using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMS.GROUP.Airport.Booking.Application.Plane.Queries.GetPlaneById;

public class GetPlaneByIdQueryValidator : AbstractValidator<GetPlaneByIdQuery>
{
    public GetPlaneByIdQueryValidator()
    {
        RuleFor(x => x.PlaneId)
            .NotEmpty().WithMessage("PlaneId is required.");
    }
}
