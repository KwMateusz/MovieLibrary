using MediatR;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateMovieHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId);
            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.Year = request.Year;
            movie.ImdbRating = request.ImdbRating;

            await _unitOfWork.MovieRepository.UpdateAsync(movie);

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}