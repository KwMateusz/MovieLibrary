using MediatR;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class RemoveMovieHandler : IRequestHandler<RemoveMovieCommand>
    {
        private IUnitOfWork _unitOfWork;

        public RemoveMovieHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId);
            await _unitOfWork.MovieRepository.RemoveAsync(category);

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}