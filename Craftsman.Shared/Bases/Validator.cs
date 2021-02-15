using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;

namespace Craftsman.Shared.Bases
{
    public abstract class Validator
    {
        protected Validator()
        => Notifications = new List<Notification>(0);

        protected bool ValidateDomain<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ErrorMessages = validator.Validate(model);

            foreach (var err in ErrorMessages.Errors)
                Notifications.Add(new Notification(err.ErrorCode, err.ErrorMessage));

            return IsValid = ErrorMessages.IsValid;
        }

        public bool IsValid { get; private set; }
        public ValidationResult ErrorMessages { get; internal set; }
        public List<Notification> Notifications { get; }
    }
}