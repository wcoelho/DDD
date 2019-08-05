using System;
using FluentValidation;
using DDD.Domain.Entities;

namespace DDD.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
{
	public UserValidator()
        {
	    RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Usuário não encontrado.");
                });
		
            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .NotNull().WithMessage("O CPF é obrigatório.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .NotNull().WithMessage("A data de nascimento é obrigatória.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .NotNull().WithMessage("O nome é obrigatório.");
        }
			}
}