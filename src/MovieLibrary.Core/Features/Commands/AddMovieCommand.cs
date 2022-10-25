using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public class AddMovieCommand : IRequest
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int Year { get; set; }

    public decimal ImdbRating { get; set; }

    public AddMovieCommand(string title, string description, int year, decimal imdbRating)
    {
        Title = title;
        Description = description;
        Year = year;
        ImdbRating = imdbRating;
    }
}