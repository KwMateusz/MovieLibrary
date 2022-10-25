using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public class RemoveMovieHandler : IRequestHandler<RemoveMovieCommand>
{
    private IUnitOfWork _unitOfWork;

    public RemoveMovieHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _unitOfWork.MovieRepository.GetByIdAsync(request.MovieId);

        if (movie == null)
            throw new MovieException($"Movie wtih id {request.MovieId} does not exist.");

        await _unitOfWork.MovieRepository.RemoveAsync(movie);
        await _unitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}