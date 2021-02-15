using FluentValidation;
using FluentValidation.Validators;

namespace Craftsman.Shared.Bases
{
    public abstract class CustomAbstractValidator<TEntity> : AbstractValidator<TEntity> where TEntity : class
    {
        protected static void ExecuteValidation(bool validation, CustomContext context, string messageFailure)
        {
            if (!validation)
                context.AddFailure(messageFailure);
        }
    }
}