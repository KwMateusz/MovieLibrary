using MediatR;
using MovieLibrary.Core.ViewModels;

namespace MovieLibrary.Core.Features.Queries;

public record GetMovieByIdQuery(int CategoryId) : IRequest<MovieViewModel>;