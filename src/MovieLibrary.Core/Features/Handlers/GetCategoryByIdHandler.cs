using AutoMapper;
using MediatR;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record GetCategoryByIdHandler(IUnitOfWork UnitOfWork, IMapper Mapper) : IRequestHandler<GetCategoryByIdQuery, CategoryViewModel>
{
    public async Task<CategoryViewModel> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        return Mapper.Map<CategoryViewModel>(await UnitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId));
    }
}