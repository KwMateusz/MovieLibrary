using MediatR;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand>
    {
        private IUnitOfWork _unitOfWork;

        public AddMovieHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.MovieRepository.AddAsync(new Movie
            {
                Title = request.Title,

                Description = request.Description,

                Year = request.Year,

                ImdbRating = request.ImdbRating
            });

            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}