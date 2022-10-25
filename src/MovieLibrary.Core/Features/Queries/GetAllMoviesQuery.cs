using MediatR;
using MovieLibrary.Core.ViewModels;
using System.Collections.Generic;

namespace MovieLibrary.Core.Features.Queries;

public record GetAllMoviesQuery : IRequest<IEnumerable<MovieViewModel>>;