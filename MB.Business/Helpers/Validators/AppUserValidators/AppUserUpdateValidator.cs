using FluentValidation;
using MB.Business.Concrete.DTOs.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.Validators.AppUserValidators
{
    public class AppUserUpdateValidator:AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Please add Id.");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Please add surname.");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Please add email.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please add correct email address.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Please add password.");
        }
    }
}
