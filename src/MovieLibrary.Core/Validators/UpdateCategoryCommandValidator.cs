using FluentValidation;
using MovieLibrary.Core.Features.Commands;

namespace MovieLibrary.Core.Validators;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(c => c.CategoryId).GreaterThan(0);
        RuleFor(c => c.Name).NotNull().NotEmpty();
    }
}