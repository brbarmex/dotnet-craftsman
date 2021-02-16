using Craftsman.Domain.Models;
using Craftsman.Shared.Bases;
using Craftsman.Shared.Constants;
using FluentValidation;

namespace Craftsman.Domain.Validators
{
    public class CustomerValidator : CustomAbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Cpf)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.CPF))
            .Custom((cpf, ctx) => ExecuteValidation(cpf.IsValid(), ctx,PropertyName.CPF, Message.ThePropertyIsInvalidPleaseVerify(PropertyName.CPF)));

            RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.Email))
            .Custom((email, ctx) => ExecuteValidation(email.IsValid(), ctx, PropertyName.CPF, Message.ThePropertyIsInvalidPleaseVerify(PropertyName.Email)));

            RuleFor(x => x.BirthDate)
            .Custom((birthDate, ctx) => ExecuteValidation(birthDate.IsAdult, ctx, PropertyName.CPF, Message.MusteBeAnAdult));

            RuleFor(x => x.Address.ZipCode)
            .Custom((zipCode, ctx) => ExecuteValidation(zipCode.IsValid(), ctx, PropertyName.CPF,  Message.ThePropertyIsInvalidPleaseVerify(PropertyName.ZipCode)));

            RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.Name))
            .Length(1, 15)
            .WithMessage(Message.InvalidNumberOfCharacters(PropertyName.Name,1,15));

            RuleFor(x => x.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.FullName))
            .Length(1, 50)
            .WithMessage(Message.InvalidNumberOfCharacters(PropertyName.FullName, 1, 50));

            RuleFor(x => x.Address.City)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.City));

            RuleFor(x => x.Address.Country)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.Country));

            RuleFor(x => x.Address.Street)
            .NotEmpty()
            .NotNull()
            .WithMessage(Message.ThePropertyIsInvalidPleaseVerify(PropertyName.Street));
        }
    }
}