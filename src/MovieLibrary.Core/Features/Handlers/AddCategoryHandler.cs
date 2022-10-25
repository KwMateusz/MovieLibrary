using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers;

public class AddCategoryHandler : IRequestHandler<AddCategoryCommand>
{
    private IUnitOfWork _unitOfWork;

    public AddCategoryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        var categories = new List<Category>(await _unitOfWork.CategoryRepository.FindAsync(x => x.Name == request.Name));
        if (categories.Count != 0)
            throw new CategoryException($"Category {request.Name} already exists!");

        await _unitOfWork.CategoryRepository.AddAsync(new Category
        {
            Name = request.Name
        });

        await _unitOfWork.SaveAsync(cancellationToken);

        return Unit.Value;
    }
}