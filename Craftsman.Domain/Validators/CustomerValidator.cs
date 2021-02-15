using Craftsman.Domain.Models;
using Craftsman.Shared.Bases;
using FluentValidation;

namespace Craftsman.Domain.Validators
{
    public class CustomerValidator : CustomAbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Cpf)
            .Custom((cpf, ctx) => ExecuteValidation(cpf.IsValid(), ctx, "The cpf is invalid, please verify."));

            RuleFor(x => x.Email)
            .Custom((email, ctx) => ExecuteValidation(email.IsValid(), ctx, "The e-mail is invalid."));

            RuleFor(x => x.BirthDate)
            .Custom((birthDate, ctx) => ExecuteValidation(birthDate.IsAdult, ctx, "Operation denied. Must be an adult."));

            RuleFor(x => x.Address.ZipCode)
            .Custom((zipCode, ctx) => ExecuteValidation(zipCode.IsValid(), ctx, "The zip-code is not valid."));

            RuleFor(x => x.Name)
            .NotEmpty().NotNull()
            .WithMessage("The name property cannot be null or empty.")
            .Length(1, 15)
            .WithMessage("The name not have length min or excedetey length max.");

            RuleFor(x => x.FullName)
            .NotEmpty().NotNull()
            .WithMessage("The full-name property cannot be null or empty.")
            .Length(1, 50)
            .WithMessage("The full-name not have length min or excedetey length max.");

            RuleFor(x => x.Address.City)
            .NotEmpty().NotNull()
            .WithMessage("The city property cannot be null or empty.");

            RuleFor(x => x.Address.Country)
            .NotEmpty().NotNull()
            .WithMessage("The country property cannot be null or empty.");

            RuleFor(x => x.Address.Street)
            .NotEmpty().NotNull()
            .WithMessage("The street property cannot be null or empty.");
        }
    }
}