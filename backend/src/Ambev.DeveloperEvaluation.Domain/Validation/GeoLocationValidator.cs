using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class GeoLocationValidator : AbstractValidator<GeoLocation>
    {
        public GeoLocationValidator()
        {
            RuleFor(g => g.Lat)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");

            RuleFor(g => g.Long)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");

        }
    }
}
