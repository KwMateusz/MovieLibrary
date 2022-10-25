using AutoMapper;
using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record GetMovieByIdHandler(IUnitOfWork UnitOfWork, IMapper Mapper) : IRequestHandler<GetMovieByIdQuery, MovieViewModel>
{
    public async Task<MovieViewModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return Mapper.Map<MovieViewModel>(await UnitOfWork.MovieRepository.GetByIdAsync(request.MovieId));
    }
}