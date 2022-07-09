using MediatR;
using MovieLibrary.Core.ViewModels;

namespace MovieLibrary.Core.Features.Queries
{
    public class GetMovieByIdQuery : IRequest<MovieViewModel>
    {
        public int MovieId { get; set; }

        public GetMovieByIdQuery(int categoryId)
        {
            MovieId = categoryId;
        }
    }
}