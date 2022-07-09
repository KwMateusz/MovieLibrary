using MediatR;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;

namespace MovieLibrary.Core.Features.Queries
{
    public class GetAllMoviesQuery : IRequest<IEnumerable<Movie>>
    {
    }
}