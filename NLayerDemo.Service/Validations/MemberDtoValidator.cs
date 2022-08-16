using FluentValidation;
using NLayerDemo.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerDemo.Service.Validations
{
    public class MemberDtoValidator : AbstractValidator<MemberDto>
    {
        public MemberDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Contact).NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull().WithMessage("{PropertyName} is required.");
            RuleFor(x => x.Logo).NotEmpty().WithMessage("{PropertyName} is required")
    .NotNull().WithMessage("{PropertyName} is required.");
        }
    }
}
