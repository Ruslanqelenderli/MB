using FluentValidation;
using MB.Business.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.Validators.LoginValidators
{
    public class LoginValidator:AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Please add email.");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please add correct email address.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Please add password.");
        }
    }
}
