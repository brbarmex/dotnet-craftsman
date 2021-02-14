using FluentValidation;
using FluentValidation.Validators;
using FP.DotNet.Domain.Models;
using FP.DotNet.Domain.ValueObjects;

namespace FP.DotNet.Domain.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Cpf)
            .Custom((cpf, ctx) => CpfIsValid(cpf, ctx));
        }

        internal static void CpfIsValid(Cpf cpf, CustomContext context)
        {
            if(cpf.IsValid())
                context.AddFailure("The cpf is invalid, please verify.");
        }
    }
}