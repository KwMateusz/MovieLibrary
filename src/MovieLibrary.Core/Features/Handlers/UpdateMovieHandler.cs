using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

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
        if (movie == null)
            throw new MovieException($"Movie wtih id {request.MovieId} does not exist.");

        var movies = new List<Movie>(await _unitOfWork.MovieRepository.FindAsync(x => x.Title == request.Title));
        if (movies.Count != 0)
            throw new MovieException($"Movie {request.Title} already exists.");

        movie.Title = request.Title;
        movie.Description = request.Description;
        movie.Year = request.Year;
        movie.ImdbRating = request.ImdbRating;

        await _unitOfWork.MovieRepository.UpdateAsync(movie);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}