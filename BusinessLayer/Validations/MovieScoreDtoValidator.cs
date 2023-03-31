using MovieRecommendation.EntityLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Validations
{
    public class MovieScoreDtoValidator : AbstractValidator<AddMovieScoreDto>
    {
        public MovieScoreDtoValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.UserId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Score).NotNull().NotEmpty().WithMessage("{PropertyName} zorunludur. ").GreaterThanOrEqualTo(1).LessThanOrEqualTo(10).WithMessage("{PropertyName} 1 ile 10 arasında olmalıdır.");
            RuleFor(x => x.Note).NotNull().NotEmpty().WithMessage("{PropertyName} zorunludur. ");
        }
    }
}
