using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace FP.DotNet.Domain.Bases
{
    public abstract class Validator
    {
        protected Validator()
        => Notifications = new List<Notifications>(0);

        protected bool ValidateDomain<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ErrorMessages = validator.Validate(model);

            foreach (var err in ErrorMessages.Errors)
                Notifications.Add(new Notifications(err.ErrorCode, err.ErrorMessage));

            return IsValid = ErrorMessages.IsValid;
        }

        public bool IsValid { get; private set;}
        public ValidationResult ErrorMessages { get; internal set;}
        public List<Notifications> Notifications { get; }
    }
}