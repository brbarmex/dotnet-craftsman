using FluentValidation;
using FP.DotNet.Domain.Bases;
using FP.DotNet.Domain.Models;

namespace FP.DotNet.Domain.Validators
{
    public class CustomerValidator : CustomAbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Cpf)
            .Custom((cpf, ctx) => ExecuteValidation(cpf.IsValid(), ctx, "The cpf is invalid, please verify."));

            RuleFor(x => x.Email)
            .Custom((email, ctx) => ExecuteValidation(email.IsValid(), ctx, "The e-mail is invalid."));

            RuleFor(x => x.Name)
            .NotEmpty().NotNull()
            .WithMessage("The name property cannot be null or empty.")
            .Length(2,15)
            .WithMessage("The name not have length min or excedetey length max.");
        }
    }
}