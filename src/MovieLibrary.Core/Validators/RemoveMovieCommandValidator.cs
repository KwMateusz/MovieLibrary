using FluentValidation;
using MovieLibrary.Core.Features.Commands;

namespace MovieLibrary.Core.Validators;

public class RemoveMovieCommandValidator : AbstractValidator<RemoveMovieCommand>
{
    public RemoveMovieCommandValidator()
    {
        RuleFor(c => c.MovieId).NotNull().GreaterThan(0);
    }
}