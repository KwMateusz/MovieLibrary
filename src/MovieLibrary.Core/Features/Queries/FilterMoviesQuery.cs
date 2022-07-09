using MediatR;
using MovieLibrary.Core.Filters;
using MovieLibrary.Core.ViewModels;
using System.Collections.Generic;

namespace MovieLibrary.Core.Features.Queries
{
    public class FilterMoviesQuery : IRequest<(IEnumerable<MovieViewModel>, object)>
    {
        public MovieParameters Parameters { get; set; }

        public FilterMoviesQuery(MovieParameters parameters)
        {
            Parameters = parameters;
        }
    }
}