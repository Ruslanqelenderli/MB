﻿using FluentValidation;
using MB.Business.Concrete.DTOs.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Business.Helpers.Validators.ProductValidators
{
    public class ProductUpdateValidator:AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Please add id.");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please add name.");
            RuleFor(x => x.Count).NotEmpty().NotNull().WithMessage("Please add count.");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("Please add categoryid.");
            RuleFor(x => x.AppUserId).NotEmpty().NotNull().WithMessage("Please add userid.");
        }
    }
}
