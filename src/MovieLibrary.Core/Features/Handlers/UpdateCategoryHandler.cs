using MediatR;
using MovieLibrary.Core.Exceptions;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Data;
using MovieLibrary.Data.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieLibrary.Core.Features.Handlers
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private IUnitOfWork _unitOfWork;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
            if (category == null)
                throw new CategoryException($"Category wtih id {request.CategoryId} does not exist.");

            var categories = new List<Category>(await _unitOfWork.CategoryRepository.FindAsync(x => x.Name == request.Name));
            if (categories.Count != 0)
                throw new CategoryException($"Category {request.Name} already exists.");

            category.Name = request.Name;

            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}