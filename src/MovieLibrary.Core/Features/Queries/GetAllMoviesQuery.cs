using MediatR;
using MovieLibrary.Core.ViewModels;
using System.Collections.Generic;

namespace MovieLibrary.Core.Features.Queries;

public class GetAllMoviesQuery : IRequest<IEnumerable<MovieViewModel>>
{
}