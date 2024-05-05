﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        { 
            RuleFor(i=>i.Name).NotEmpty();
            RuleFor(i=>i.Name).MinimumLength(2);
        }

    }
}
