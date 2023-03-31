using FluentValidation;
using MovieRecommendation.EntityLayer.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MovieRecommendation.BusinessLayer.Validations
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} zorunlu");
            RuleFor(x => x.UserName).NotNull().NotEmpty().WithMessage("{PropertyName} zorunlu");

            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("{PropertyName} zorunlu")
                                 .EmailAddress().WithMessage("A valid email is required");

            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} zorunlu");

            RuleFor(x => x.SurName).NotNull().NotEmpty().WithMessage("{PropertyName} zorunlu");

            RuleFor(p => p.Password).MaximumLength(16).WithMessage("Şifreniz Maximum 16 karakter olabilir.")
           .NotEmpty().WithMessage("{PropertyName} zorunlu");
           //.Must(IsPasswordValid).WithMessage("Şifreniz en az sekiz karakter, en az bir harf ve bir rakamdan oluşmalıdır.!");
        }
        //private bool IsPasswordValid(string arg)
        //{
        //    Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        //    return regex.IsMatch(arg);
        //}
    }
}
