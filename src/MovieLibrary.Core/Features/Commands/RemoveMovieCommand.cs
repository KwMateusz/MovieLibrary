using MediatR;

namespace MovieLibrary.Core.Features.Commands;

public record RemoveMovieCommand(int MovieId) : IRequest;