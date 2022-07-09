using MediatR;

namespace MovieLibrary.Core.Features.Commands
{
    public class RemoveMovieCommand : IRequest
    {
        public int MovieId { get; set; }

        public RemoveMovieCommand(int movieId)
        {
            MovieId = movieId;
        }
    }
}