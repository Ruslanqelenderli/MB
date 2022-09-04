using FluentValidation;
using MB.Business.Concrete.DTOs.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.Validators.CategoryValidators
{
    public class CategoryAddValidator:AbstractValidator<CategoryAddDto>
    {
        public CategoryAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
        }
    }
}
