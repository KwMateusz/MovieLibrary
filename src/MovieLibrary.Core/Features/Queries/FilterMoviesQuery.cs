using MediatR;
using MovieLibrary.Core.Filters;
using MovieLibrary.Core.ViewModels;
using System.Collections.Generic;

namespace MovieLibrary.Core.Features.Queries;

public record FilterMoviesQuery(MovieParameters Parameters) : IRequest<(IEnumerable<MovieViewModel>, object)>;
