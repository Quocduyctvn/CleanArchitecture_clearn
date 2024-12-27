using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Features.Products.Commands
{
	public class CraeteProductCommandValidator : AbstractValidator<CreateProductCommand>
	{
        public CraeteProductCommandValidator()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} là bắt buột")
                .Length(2, 10).WithMessage("{PropertyName} phaỉ tối thiểu 2 và tối da 10");

            RuleFor(i => i.Rate)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} là bắt buột")
                .LessThan(500);
		}
    }
}
