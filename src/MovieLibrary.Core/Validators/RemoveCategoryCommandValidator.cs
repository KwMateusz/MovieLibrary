using FluentValidation;
using MovieLibrary.Core.Features.Commands;

namespace MovieLibrary.Core.Validators
{
    public class RemoveCategoryCommandValidator : AbstractValidator<RemoveCategoryCommand>
    {
        public RemoveCategoryCommandValidator()
        {
            RuleFor(c => c.CategoryId).NotNull().GreaterThan(0);
        }
    }
}