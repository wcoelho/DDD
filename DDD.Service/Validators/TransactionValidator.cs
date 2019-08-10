using System;
using FluentValidation;
using DDD.Domain.Entities;

namespace DDD.Service.Validators
{
    public class TransactionValidator : AbstractValidator<Transaction>
    {
        public TransactionValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Transação não encontrada.");
                    });
            RuleFor(c => c.Value)
                    .NotEmpty().WithMessage("O valor é mandatório.")
                    .NotNull().WithMessage("O valor é mandatório.");

        }
	}
}