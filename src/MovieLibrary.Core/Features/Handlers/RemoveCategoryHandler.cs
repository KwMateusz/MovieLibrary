using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record RemoveCategoryHandler(IUnitOfWork UnitOfWork) : IRequestHandler<RemoveCategoryCommand>
{
    public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await UnitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);

        if (category == null)
            throw new CategoryException($"Category wtih id {request.CategoryId} does not exist.");

        await UnitOfWork.CategoryRepository.RemoveAsync(category);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}