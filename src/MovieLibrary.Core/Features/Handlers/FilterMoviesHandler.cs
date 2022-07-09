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

namespace MovieLibrary.Core.Features.Handlers
{
    public class FilterMoviesHandler : IRequestHandler<FilterMoviesQuery, (IEnumerable<MovieViewModel>, object)>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FilterMoviesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<MovieViewModel>, object)> Handle(FilterMoviesQuery request, CancellationToken cancellationToken)
        {
            var filteredResult = await ((MovieRepository)_unitOfWork.MovieRepository).FilterAsync(request.Parameters);
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

            var result = _mapper.Map<IEnumerable<MovieViewModel>>(filteredResult);
            return (result, metadata);
        }
    }
}