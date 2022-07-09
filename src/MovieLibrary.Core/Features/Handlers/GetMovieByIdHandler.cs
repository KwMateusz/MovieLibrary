using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class GetMovieByIdHandler : IRequestHandler<GetMovieByIdQuery, Movie>
    {
        private IUnitOfWork _unitOfWork;

        public GetMovieByIdHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId);
        }
    }
}