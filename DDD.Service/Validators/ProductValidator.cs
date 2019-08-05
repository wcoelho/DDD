using System;
using FluentValidation;
using DDD.Domain.Entities;

namespace DDD.Service.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Produto não encontrado.");
                    });
            
                RuleFor(c => c.Name)
                    .NotEmpty().WithMessage("O nome do produto é mandatório.")
                    .NotNull().WithMessage("O nome do produto é mandatório.");

                RuleFor(c => c.Code)
                    .NotEmpty().WithMessage("O código do produto é mandatório.")
                    .NotNull().WithMessage("O código do produto é mandatório.");

                RuleFor(c => c.Manufacturer)
                    .NotEmpty().WithMessage("O nome do fabricante é mandatório.")
                    .NotNull().WithMessage("O nome do fabricante é mandatório.");

                RuleFor(c => c.Price)
                    .GreaterThanOrEqualTo(0).WithMessage("O preço do produto deve ser maior do que zero.")
                    .NotEmpty().WithMessage("O preço do produto é mandatório.")
                    .NotNull().WithMessage("O preço do produto é mandatório.");

                RuleFor(c => c.SKU)
                    .NotEmpty().WithMessage("O SKU é mandatório.")
                    .NotNull().WithMessage("O SKU é mandatório.");
        }
	}
}