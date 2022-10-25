using FluentValidation;
using MovieLibrary.Core.Features.Commands;
using System;

namespace MovieLibrary.Core.Validators;

public class AddMovieCommandValidator : AbstractValidator<AddMovieCommand>
{
    public AddMovieCommandValidator()
    {
        RuleFor(c => c.Title).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(c => c.Description).NotNull().NotEmpty().MaximumLength(200);
        RuleFor(c => c.Year).LessThanOrEqualTo(DateTime.Now.Year).GreaterThanOrEqualTo(1888);
        RuleFor(c => c.ImdbRating).LessThanOrEqualTo(10).GreaterThanOrEqualTo(0);
    }
}