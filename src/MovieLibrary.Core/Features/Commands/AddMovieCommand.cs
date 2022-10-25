using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public record AddMovieCommand(string Title, string Description, int Year, decimal ImdbRating) : IRequest;