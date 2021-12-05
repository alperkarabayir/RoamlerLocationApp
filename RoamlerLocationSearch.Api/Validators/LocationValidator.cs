using FluentValidation;
using RoamlerLocationSearch.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenFluxAssignment.Api.Validators
{
    public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.Latitude)
                .GreaterThan(-90)
                .WithMessage("Latitude can not be less than -90");

            RuleFor(x => x.Latitude)
                .LessThan(90)
                .WithMessage("Latitude can not be less than -90");

            RuleFor(x => x.Longitude)
                .GreaterThan(-180)
                .WithMessage("Longitude can not be less than -1800");

            RuleFor(x => x.Longitude)
                .LessThan(180)
                .WithMessage("Longitude can not be less than -180");
        }
    }
}
