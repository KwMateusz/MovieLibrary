using AutoMapper;
using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record GetAllCategoriesHandler(IUnitOfWork UnitOfWork, IMapper Mapper) : IRequestHandler<GetAllCategoriesQuery, IEnumerable<CategoryViewModel>>
{
    public async Task<IEnumerable<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        return Mapper.Map<IEnumerable<CategoryViewModel>>(await UnitOfWork.CategoryRepository.GetAllAsync());
    }
}