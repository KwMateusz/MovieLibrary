using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record RemoveMovieHandler(IUnitOfWork UnitOfWork) : IRequestHandler<RemoveMovieCommand>
{
    public async Task<Unit> Handle(RemoveMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await UnitOfWork.MovieRepository.GetByIdAsync(request.MovieId);

        if (movie == null)
            throw new MovieException($"Movie wtih id {request.MovieId} does not exist.");

        await UnitOfWork.MovieRepository.RemoveAsync(movie);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}