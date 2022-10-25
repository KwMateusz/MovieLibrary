using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public class AddMovieHandler : IRequestHandler<AddMovieCommand>
{
    private IUnitOfWork _unitOfWork;

    public AddMovieHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        var movies = new List<Movie>(await _unitOfWork.MovieRepository.FindAsync(x => x.Title == request.Title));
        if (movies.Count != 0)
            throw new MovieException($"Movie {request.Title} already exists.");

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