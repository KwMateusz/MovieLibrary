using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public class UpdateMovieCommand : IRequest
{
    public int MovieId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Year { get; set; }

    public decimal ImdbRating { get; set; }

    public UpdateMovieCommand(int movieId, string title, string description, int year, decimal imdbRating)
    {
        MovieId = movieId;
        Title = title;
        Description = description;
        Year = year;
        ImdbRating = imdbRating;
    }
}