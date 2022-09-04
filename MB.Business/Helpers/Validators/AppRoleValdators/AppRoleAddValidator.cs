using FluentValidation;
using MB.Business.Concrete.DTOs.RoleDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.Validators.AppRoleValdators
{
    public class AppRoleAddValidator:AbstractValidator<RoleAddDto>
    {
        public AppRoleAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Please add description.");
        }
    }
}
