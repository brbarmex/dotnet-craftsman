using FluentValidation;
using FluentValidation.Validators;

namespace Craftsman.Shared.Bases
{
    public abstract class CustomAbstractValidator<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
        protected static void ExecuteValidation(bool validation, CustomContext context, string failure)
        {
            if (!validation)
                context.AddFailure(failure);
        }

        protected static void ExecuteValidation(bool validation, CustomContext context, string property, string failure)
        {
            if (!validation)
                context.AddFailure(property,failure);
        }
    }
}