using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public record UpdateCategoryHandler(IUnitOfWork UnitOfWork) : IRequestHandler<UpdateCategoryCommand>
{
    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await UnitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
        if (category == null)
            throw new CategoryException($"Category wtih id {request.CategoryId} does not exist.");

        var categories = new List<Category>(await UnitOfWork.CategoryRepository.FindAsync(x => x.Name == request.Name));
        if (categories.Count != 0)
            throw new CategoryException($"Category {request.Name} already exists.");

        category.Name = request.Name;

        await UnitOfWork.CategoryRepository.UpdateAsync(category);
        await UnitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}