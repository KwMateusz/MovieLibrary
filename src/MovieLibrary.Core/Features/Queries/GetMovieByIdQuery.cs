using MediatR;
using MovieLibrary.Data.Entities;

namespace MovieLibrary.Core.Features.Queries
{
    public class GetMovieByIdQuery : IRequest<Movie>
    {
        public int MovieId { get; set; }

        public GetMovieByIdQuery(int categoryId)
        {
            MovieId = categoryId;
        }
    }
}