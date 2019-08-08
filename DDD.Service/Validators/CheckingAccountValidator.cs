using System;
using FluentValidation;
using DDD.Domain.Entities;

namespace DDD.Service.Validators
{
    public class CheckingAccountValidator : AbstractValidator<CheckingAccount>
    {
        public CheckingAccountValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Conta Corrente não encontrada.");
                    });                     
        }
	}
}