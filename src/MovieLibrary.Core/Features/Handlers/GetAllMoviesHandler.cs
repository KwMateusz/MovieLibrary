using AutoMapper;
using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record GetAllMoviesHandler(IUnitOfWork UnitOfWork, IMapper Mapper) : IRequestHandler<GetAllMoviesQuery, IEnumerable<MovieViewModel>>
{
    public async Task<IEnumerable<MovieViewModel>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
    {
        return Mapper.Map<IEnumerable<MovieViewModel>>(await UnitOfWork.MovieRepository.GetAllAsync());
    }
}