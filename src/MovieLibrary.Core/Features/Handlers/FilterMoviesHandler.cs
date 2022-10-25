using AutoMapper;
using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.Repositories;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Filters;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record FilterMoviesHandler(IUnitOfWork UnitOfWork, IMapper Mapper) : IRequestHandler<FilterMoviesQuery, (IEnumerable<MovieViewModel>, object)>
{
    public async Task<(IEnumerable<MovieViewModel>, object)> Handle(FilterMoviesQuery request, CancellationToken cancellationToken)
    {
        var filteredResult = await ((MovieRepository)UnitOfWork.MovieRepository).FilterAsync(request.Parameters);
        var resultAsPagedList = (PagedList<Movie>)filteredResult;
        object metadata = new
        {
            resultAsPagedList.TotalCount,
            resultAsPagedList.PageSize,
            resultAsPagedList.CurrentPage,
            resultAsPagedList.TotalPages,
            resultAsPagedList.HasNext,
            resultAsPagedList.HasPrevious
        };

        var result = Mapper.Map<IEnumerable<MovieViewModel>>(filteredResult);
        return (result, metadata);
    }
}