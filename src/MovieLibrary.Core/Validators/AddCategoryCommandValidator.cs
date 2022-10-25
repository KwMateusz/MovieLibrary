using FluentValidation;
using MovieLibrary.Core.Features.Commands;

namespace MovieLibrary.Core.Validators;

public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
{
    public AddCategoryCommandValidator()
    {
        RuleFor(c => c.Name).NotNull().NotEmpty();
    }
}