using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public record UpdateMovieCommand(int MovieId, string Title, string Description, int Year, decimal ImdbRating) : IRequest;