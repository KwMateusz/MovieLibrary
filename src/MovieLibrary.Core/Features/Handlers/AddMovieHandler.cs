using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record AddMovieHandler(IUnitOfWork UnitOfWork) : IRequestHandler<AddMovieCommand>
{
    public async Task<Unit> Handle(AddMovieCommand request, CancellationToken cancellationToken)
    {
        var movies = new List<Movie>(await UnitOfWork.MovieRepository.FindAsync(x => x.Title == request.Title));
        if (movies.Count != 0)
            throw new MovieException($"Movie {request.Title} already exists.");

        await UnitOfWork.MovieRepository.AddAsync(new Movie
        {
            Title = request.Title,

            Description = request.Description,

            Year = request.Year,

            ImdbRating = request.ImdbRating
        });
        await UnitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}